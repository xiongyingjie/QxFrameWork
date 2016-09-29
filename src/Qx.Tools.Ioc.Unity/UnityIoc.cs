using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Qx.Contents.Interfaces;
using Qx.Contents.Services;
using Qx.Permission.Entity;
using Qx.Permission.Interfaces;
using Qx.Permission.Repository;
using Qx.Permission.Services;
using Qx.Report;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Tools.Interfaces;


namespace Qx.Tools.Ioc.Unity
{
    public static class UnityIoc
    {
        public static void Register(List<Type> controllers)
        {
            //Container
            IUnityContainer container = new UnityContainer();
            //Register controllers
            controllers.ForEach(c => container.RegisterType(c));
            //Register Services
            RegisterServices(container);
            //Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        static void RegisterServices(IUnityContainer container)
        {
            
            #region Permission Repository
            #region Permission Repository
            container.RegisterType<IRepository<Button>, ButtonRepository>();
            container.RegisterType<IRepository<Menu>, MenuRepository>();
            container.RegisterType<IRepository<RoleButtonForbid>, RoleButtonForbidRepository>();
            container.RegisterType<IRepository<RoleMenu>, RoleMenuRepository>();
            container.RegisterType<IRepository<Role>, RoleRepository>();
            container.RegisterType<IRepository<User>, UserRepository>();
            container.RegisterType<IRepository<UserRole>, UserRoleRepository>();


            #endregion

            #endregion


            #region Contents Repository
            container.RegisterType<IRepository<Qx.Contents.Entity.ContentColumnDesign>, Qx.Contents.Repository.ContentColumnDesignRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.ContentColumnValue>, Qx.Contents.Repository.ContentColumnValueRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.ContentTableDesign>, Qx.Contents.Repository.ContentTableDesignRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.ContentTableQuery>, Qx.Contents.Repository.ContentTableQueryRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.ContentType>, Qx.Contents.Repository.ContentTypeRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.DataType>, Qx.Contents.Repository.DataTypeRepository>();
            container.RegisterType<IRepository<Qx.Contents.Entity.PageControlType>, Qx.Contents.Repository.PageControlTypeRepository>();
            #endregion


            container.RegisterType<IContents, ContentService>();

            container.RegisterType<IReportServices, ReportServices>();

            container.RegisterType<IPermission, PermissionServices>();
        }
      
    }
}
