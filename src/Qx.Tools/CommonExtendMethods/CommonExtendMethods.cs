using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Qx.Tools.CommonExtendMethods
{
    public static class CommonExtendMethods
    {
        //public static UnityIoc Controllers<T>(this UnityIoc ioc)
        //{
        //    UnityIoc.Register(UnityIoc.GetSubClasses<T>());
        //}

        public static List<List<string>> ToTableList(this SqlDataReader reader)
        {
            //所有行
            var rows = new List<List<string>>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //逐行添加内容
                    var cols = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var value = "";
                        #region 根据格式取值
                        var type = reader.GetDataTypeName(i).ToLower();
                        if (reader.IsDBNull(i))
                        {
                            value = "";
                        }
                        else if (type.Contains("int"))
                        {
                            var v = reader.GetInt32(i);
                            if (v > 1000000000)
                            {
                                value = reader.GetInt32(i).ToDateTime().ToStr();
                            }
                            else
                            {
                                value = reader.GetInt32(i) + "";
                            }

                        }
                        else if (type.Contains("float"))
                        {
                            value = reader.GetDouble(i) + "";
                        }
                        else if (type.Contains("datetime"))
                        {
                            value = reader.GetDateTime(i).ToString("yyyy-MM-dd HH:mm") + "";
                        }
                        else
                        {

                            value = (reader.GetString(i) + "");
                                  // Replace("%", "");//2016-09-05 配合报表转义规则 2016-09-10 更新规则
                            //if (value.Contains("%"))
                            //    throw new Exception("替换不完全！");
                        }
                        #endregion
                        cols.Add(value);
                    }
                    rows.Add(cols);
                }
            }
            reader.Close();
            reader.Dispose();
            return rows;
        }
     


        #region 通用

       
        public static bool IsSame<T, K>(this object obj)
        {
            return typeof(T).Name == typeof(K).Name;
        }
        #endregion


       

        #region List<List<string>>相关

        public static List<List<string>> AddCol(this List<List<string>> rows, List<string> col)
        {
            if (rows.Count != col.Count)
                throw new Exception("待插入的列的个数与原有行数不匹配");
            var dest = new List<List<string>>();
            for (var i = 0; i < rows.Count; i++)
            {
                var newRow = new List<string>();
                newRow.AddRange(rows[i]);
                newRow.Add(col[i]);
                dest.Add(newRow);
            }
            return dest;
        }
        public static List<List<string>> AddRow(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Add(row);
            return rows;
        }
        public static List<List<string>> AddRowToFirst(this List<List<string>> rows, List<string> row)
        {
            if (rows.Count > 0 && rows[0].Count != row.Count)
                throw new Exception("待插入的行的列数与原有列数不匹配");
            rows.Insert(0, row);
            return rows;
        }
        public static List<List<string>> FilterRows(this List<List<string>> rows, List<string> indexToShow)
        {
            return rows.Select(row => FilterRow(row, indexToShow)).ToList();
        }

      
        #endregion

        #region List<string> 相关

        public static string PackString(this List<string> srcList, char flag = ';')
        {
            string tempString = "";

            if (srcList.Count > 0)//是否为空,只处理非空
            {
                for (int l = 0; l < srcList.Count; l++)
                {
                    tempString += srcList[l];//构造认证字符串
                    if (l < srcList.Count - 1)
                    {
                        tempString += flag;
                    }
                }
            }

            return tempString;
        }
        public static string[] FormatString(this List<string> srcString, char flag = '%')
        {
            return srcString.Select(o => flag + o + flag).ToArray();
        }
        #endregion

       

        #region List<T> 相关
        public static List<T> Grap<T>(this List<T> data, int start, int end)
        {
            var dest = new List<T>();
            for (var i = start; i <= end && i < data.Count; i++)
            {
                dest.Add(data[i]);
            }
            return dest;
        }


        public static List<T> GetPage<T>(this List<T> list, int pageIndex, int perCount,out int maxIndex)
        {
           maxIndex = (int)Math.Ceiling(double.Parse(list.Count.ToString()) / perCount);
         
            var datas = list.ToList();
            var startIndex = perCount * (pageIndex - 1);
            //是否越界
            if(pageIndex<=0)
                return new List<T>();

            if (startIndex + perCount - 1 < datas.Count)
            {
                return datas.GetRange(startIndex, perCount);
            }
            else
            {
                //是否因为是最后一页而越界               
                if (startIndex < datas.Count)
                {
                    return datas.GetRange(startIndex, datas.Count - startIndex);
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> list, int pageIndex, int perCount, out int maxIndex)
        {
            var datas = list.ToList();
            return datas.GetPage(pageIndex, perCount, out maxIndex);
        }

        #endregion

        #region List<SelectListItem> 相关
        public static List<SelectListItem> Format(this List<SelectListItem> items, string selectedValue)
        {
            items = items.Distinct(Equality<SelectListItem>.CreateComparer(p => p.Value)).ToList();

            items.Add(new SelectListItem() { Text = "请选择", Value = "" });
            items.ForEach(a =>
            {
                if (a.Value == selectedValue || a.Text == selectedValue)
                {
                    a.Selected = true;
                }
            });
            return items;
        }

        #endregion

        #region List<string> 相关

        public static string ToString(this List<string> list, string splitFlag = " ")
        {
            var dest = "";
            list.ForEach(item =>
            {
                dest += item + splitFlag;
            });
            return dest;
        }
        public static List<string> FilterRow(this List<string> row, List<string> indexToShow)
        {
            var dest = new List<string>();

            for (var i = 0; i < row.Count; i++)
            {
                if (indexToShow.Contains(i.ToString()))
                {
                    dest.Add(row[i]);
                }
            }

            return dest;
        }

       
        #endregion

        #region DateTime 相关

        public static int Random(this DateTime time)
            {
                return new Random(new Random(DateTime.Now.Millisecond).Next()).Next();
            }
            public static string TimeToNow(this DateTime time)
            {
                return ((int)(DateTime.Now - time).TotalDays) + "天前";
            }
            public static string ToStr(this DateTime time, bool showToNow = false)
            {
                var temp = time.ToLongDateString() + " " + time.ToLongTimeString();
                return showToNow ? temp + "(" + TimeToNow(time) + ")" : temp;
            }
                    
            public static int ToInt(this DateTime time)
            {
                var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                return (int)(time - startTime).TotalSeconds;
            }
            public static string ToTimeStr(this DateTime time)
            {

                return time.ToLongDateString() + " " + time.ToLongTimeString();
            }
#endregion

        #region Type 相关
            //获取Controller下的public action =>通过反射获取Controller的子方法
            public static List<MethodInfo> GetSubActions(this Type t)
            {
                return t.GetMethods().Where(m => m.ReturnType == typeof(ActionResult) && m.IsPublic == true).ToList();
            }
            //获取所有的Controllers =>通过反射获取Controller的子类
            public static List<Type> GetSubClasses(this Type type)
            {
                return Assembly.GetCallingAssembly().GetTypes().Where(
                    t => t.IsSubclassOf(type)).ToList();
            }

            public static List<Type> GetAllTypes(this object obj, List<string> AssemblieFilter, List<string> NamespaceFilter)
            {
                
                var allAssemlys = AppDomain.CurrentDomain.GetAssemblies().ToList();
                var filteredAssemlys =new List<Assembly>();

                var allTypes = new List<Type>();
                var filteredTypes = new List<Type>();

                AssemblieFilter.ForEach(a =>
                {
                    filteredAssemlys.AddRange(allAssemlys.Where(b=>b.FullName.Contains(a)));
                });
                for (int i = 0; i < filteredAssemlys.Count; i++)
                {

                    try
                    {
                        allTypes.AddRange(allAssemlys[i].GetTypes());
                    }
                    catch (Exception)
                    {
                        i++;
                        //越过异常 throw;
                    }
                }

                NamespaceFilter.ForEach(a =>
                {
                    filteredTypes.AddRange(allTypes.Where(b => b.FullName.Contains(a)));
                });
                return filteredTypes;
            }

            public static Dictionary<Type, Type> GetClassInterfaceDic(this List<Type> Types)
            {
                var dest = new Dictionary<Type, Type>();

                var interfaces = Types.Where(a => a.IsInterface);
                var classes = Types.Where(a => !a.IsInterface);

                foreach (var _interface in interfaces)
                {
                    foreach (var _class in classes.Where(a=> (a.GetInterfaces().Contains(_interface))))//实现该接口的所有类
                    {
                        //如果出现一个接口被多个类实现，这里会执行多次，对于ioc是非常不利的！！
                        //采用dictionary 可以避免避免插入重复匹配记录
                        try
                        {
                            dest.Add(_interface, _class);
                        }
                        catch (Exception ex)
                        {
                           break; //检测到重复 做中断处理
                        }
                       
                    }
                }
             
                return dest;
            }

            #endregion

        #region string 相关
            public static SqlDataReader ExecuteReader(this string sql, string connStr)
            {
                SqlDataReader reader;
                var Con = new SqlConnection(connStr);

                var Com = new SqlCommand(sql, Con);
                try
                {
                    Con.Open();
                    reader = Com.ExecuteReader();
                }
                catch (Exception ex)
                {
                
                    throw ex;
                }
                
                return reader;
            }
            public static int ExecuteNonQuery(this string sql, string connStr)
            {
                var count = 0;
                using (var Con = new SqlConnection(connStr))
                {
                    var Com = new SqlCommand(sql, Con);
                    try
                    {
                        Con.Open();
                        count = Com.ExecuteNonQuery();
                        Con.Close();
                        Con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("数据库连接失败! \n"+ex.Message);
                    }
                }

                return count;
            }
            public static List<string> UnPackString(this string srcString, char flag ,bool removeEmpty=false)
            {
                //关于控制检测
                //若数据库 存在该行，但是该列为空，此时读出的字符串 ""
                //若数据库 不存在该行 此时读出的字符串 null

                if (!string.IsNullOrEmpty(srcString))//是否为空 既然能传入肯定不是null
                {
                    srcString.Trim();//清除空格
                    List<string> temp = srcString.Split(flag).ToList<string>();    //拆分成数组  
                    if (removeEmpty)
                    {
                        if (temp[temp.Count - 1] == "")
                        {
                            temp.RemoveAt(temp.Count - 1);
                        }
                    }
                   
                    return temp;
                }
                else
                {
                    return new List<string>(0);
                }
            }

            public static bool HasValue(this string srcString)
            {
                if (string.IsNullOrWhiteSpace(srcString))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            public static int ToInt(this string srcString)
            {
                if (srcString.HasValue())
                {
                    return int.Parse(srcString);
                }
                else
                {
                    return -1;
                }
            }
            #endregion

        #region int 相关
            public static DateTime ToDateTime(this int time)
            {
                var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                return startTime.AddSeconds(time);

            }

            #endregion

        #region Entity 相关
            public static bool Saved(this DbContext db)
            {
                db.SaveChanges();
                return true;

        }
            public static bool SaveAdd(this DbContext db, object entity)
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
                return  true;
            }
            public static bool SaveDelete(this DbContext db, object entity)
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            public static bool SaveModified(this DbContext db, object entity)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
        }

            public static bool Save<T>(this T table, DbContext db) where T : class
            {
                return db.Saved();
            }
            #endregion


        #region 快速创建 IEqualityComparer<T> 的实例
        //var equalityComparer1 = Equality<Person>.CreateComparer(p => p.ID);
        public static class Equality<T>
        {
            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
            {
                return new CommonEqualityComparer<V>(keySelector);
            }
            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                return new CommonEqualityComparer<V>(keySelector, comparer);
            }

            class CommonEqualityComparer<V> : IEqualityComparer<T>
            {
                private Func<T, V> keySelector;
                private IEqualityComparer<V> comparer;

                public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
                {
                    this.keySelector = keySelector;
                    this.comparer = comparer;
                }
                public CommonEqualityComparer(Func<T, V> keySelector)
                    : this(keySelector, EqualityComparer<V>.Default)
                { }

                public bool Equals(T x, T y)
                {
                    return comparer.Equals(keySelector(x), keySelector(y));
                }
                public int GetHashCode(T obj)
                {
                    return comparer.GetHashCode(keySelector(obj));
                }
            }
        }
        #endregion

        #region 快速创建 IComparer<T> 的实例
        //var comparer1 = Comparison<Person>.CreateComparer(p => p.ID);
        public static class Comparison<T>
        {
            public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector)
            {
                return new CommonComparer<V>(keySelector);
            }
            public static IComparer<T> CreateComparer<V>(Func<T, V> keySelector, IComparer<V> comparer)
            {
                return new CommonComparer<V>(keySelector, comparer);
            }

            class CommonComparer<V> : IComparer<T>
            {
                private Func<T, V> keySelector;
                private IComparer<V> comparer;

                public CommonComparer(Func<T, V> keySelector, IComparer<V> comparer)
                {
                    this.keySelector = keySelector;
                    this.comparer = comparer;
                }
                public CommonComparer(Func<T, V> keySelector)
                    : this(keySelector, Comparer<V>.Default)
                { }

                public int Compare(T x, T y)
                {
                    return comparer.Compare(keySelector(x), keySelector(y));
                }
            }
        }
        #endregion
    }
}
