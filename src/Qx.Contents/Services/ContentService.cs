using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Qx.Contents.Entity;
using Qx.Contents.Interfaces;
using Qx.Contents.Models;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Contents.Services
{
   

    public class ContentService: BaseRepository, IContents
    {
        public TableDesign GetTableDesign(string tableId )
        {
            var dest=Db.ContentTableDesigns.Where(a => a.CTD_ID == tableId).
                Select(b => new TableDesign()
                {
                    TableID = b.CTD_ID,
                    TypeID = b.CT_ID,
                    TypeName = b.ContentType.TypeName,
                    TableName = b.TableName,
                    Columns = b.ContentColumnDesigns.
                    Select(c=>new TableColumn()
                    {
                        ColumnID = c.CCD_ID,
                        DateTypeID = c.DT_ID,
                        PageControlID = c.PCT_ID,
                        ColumnName = c.ColumnName,
                        DateTypeName = c.ColumnName,
                        PageControlName = c.PageControlType.PCT_Name,
                        Seq = c.Seq,
                        IsPk = c.IsPk,
                        DefValue = c.DefValue,
                        Value = "警告:要获取各列的值请调用方法 GetTableValue(string tableId, string relationKeyId)"
                    }).
                    OrderBy(d=>d.Seq)
                });
            if (dest.Any())
            {
                return dest.FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("tableId不存在，请确保传入了正确的tableId，当前传入的tableId是 '{0}'", tableId)); ;
            }
               
               
        }
        public TableValue GetTableValue(string tableId, string relationKeyId)
        {
            var dest = Db.ContentTableDesigns.Where(a => a.CTD_ID == tableId).
                Select(b => new TableValue()
                {
                    TableID = b.CTD_ID,
                    TypeID = b.CT_ID,
                    RelationKeyID = relationKeyId,
                    TypeName = b.ContentType.TypeName,
                    TableName = b.TableName,
                    Columns = b.ContentColumnDesigns.
                    Select(c => new TableColumn()
                    {
                        ColumnID = c.CCD_ID,
                        DateTypeID = c.DT_ID,
                        PageControlID = c.PCT_ID,
                        ColumnName = c.ColumnName,
                        DateTypeName = c.ColumnName,
                        PageControlName = c.PageControlType.PCT_Name,
                        Seq = c.Seq,
                        IsPk = c.IsPk,
                        DefValue = c.DefValue,
                        Value = c.ContentColumnValues.FirstOrDefault(d=>d.CCD_ID==c.CCD_ID&&d.RelationKeyValue==relationKeyId).ColumnValue
                    }).
                    OrderBy(d => d.Seq)
                });
            if (dest.Any())
            {
                return dest.FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("tableId不存在，请确保传入了正确的tableId，当前传入的tableId是 '{0}'", tableId)); ;
            }


        }
        public bool UpdateTable(ContentBag contentValueBag)
        {
            var rule = GetTableDesign(contentValueBag.TableId);
            //验证数据合法性
            var require = rule.Columns;
            var real = contentValueBag.Values;
            if (require.Count() != real.Count())
            {
                throw new Exception(string.Format("参数个数不匹配，应该传入的参数个数是'{0}',实际传入的个数是'{1}'", require, real));
            }
            if (require.Select(a => a.ColumnID).ToList().Except(real.Select(b => b.ColumnID)).Any())
            {
                throw new Exception(string.Format("参数不匹配，应该传入的参数是'{0}',实际传入的是'{1}'", String.Concat(require.Select(a => a.ColumnID + ",")), String.Concat(real.Select(a => a.ColumnID + ","))));
            }
            contentValueBag.Values.ToList().ForEach(a =>
            {    
                var model=new ContentColumnValue()
                {
                    CCV_ID = a.ColumnID+"-"+a.RelationKeyID,
                    CCD_ID = a.ColumnID,
                    ColumnValue = a.ColumnValue,
                    RelationKeyValue = a.RelationKeyID.HasValue() ? 
                                                a.RelationKeyID : 
                                                Db.ContentColumnDesigns.NoTrackingFind(b=>b.CCD_ID==a.ColumnID).DefValue//设置默认值
                };
                  //是否存在旧数据
                if (Db.ContentColumnValues.Any(b => b.CCV_ID == model.CCV_ID))
                {
                    Db.Entry(model).State=EntityState.Modified;
                }
                else
                {
                    Db.ContentColumnValues.Add(model);
                }
            });
            return Db.Saved();
        }

        public bool UpdateTable(HttpRequestBase request,string tableId,string relationKeyId)
        {
            var rule = GetTableDesign(tableId);
            //从表单提取数据
            var dest = new ContentBag()
            {
                TableId = tableId,
                Values = rule.Columns.Select(a =>
                                   new ContentValue()
                                   {
                                       ColumnID = a.ColumnID,
                                       ColumnValue = request.Form[a.ColumnID],
                                       RelationKeyID = relationKeyId
                                   }
            )
            };

            return UpdateTable(dest);
        }
    }
}
