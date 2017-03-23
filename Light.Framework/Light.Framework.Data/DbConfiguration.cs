using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Linq.Expressions;
using Light.Framework.Core.Security;
using Light.Framework.Data.Entities;
using Microsoft.Practices.ObjectBuilder2;

namespace Light.Framework.Data
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public sealed class DbConfiguration : DbMigrationsConfiguration<LightDbContext>
    {
        private readonly DateTime _now = new DateTime(2015, 5, 1, 23, 59, 59);

        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = true;//启用自动迁移
            AutomaticMigrationDataLossAllowed = true;//是否允许接受数据丢失的情况，false=不允许，会抛异常；true=允许，有可能数据会丢失

            //解决数据迁移时，ef 对 mysql 语句添加 dbo 报错的问题
            //SetSqlGenerator("MySql.Data.MySqlClient", new MyCodeGenerator());
        }

        protected override void Seed(LightDbContext context)
        {

                #region 菜单

                var system = new Menu
                {
                    Name = "系统设置",
                    Url = "#",
                    Icon = "fa fa-clone",
                    AddTime = _now,
                    Order = 1,
                    Type = 1
                }; //1
                var menuMgr = new Menu
                {
                    ParentId = system.Id,
                    Name = "菜单管理",
                    Url = "/Menu/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                }; //2
                var departmentMgr = new Menu
                {
                    ParentId = system.Id,
                    Name = "部门管理",
                    Url = "/Department/Index",
                    AddTime = _now,
                    Order = 3,
                    Type = 2
                }; //3
                var roleMgr = new Menu
                {
                    ParentId = system.Id,
                    Name = "角色管理",
                    Url = "/Role/Index",
                    AddTime = _now,
                    Order = 3,
                    Type = 2
                }; //3
                var userMgr = new Menu
                {
                    ParentId = system.Id,
                    Name = "用户管理",
                    Url = "/User/Index",
                    AddTime = _now,
                    Order = 4,
                    Type = 2
                }; //4
                var userRoleMgr = new Menu
                {
                    ParentId = userMgr.Id,
                    Name = "用户授权",
                    Url = "/User/Authen",
                    AddTime = _now,
                    Order = 4,
                    Type = 2
                }; //5
                var roleMenuMgr = new Menu
                {
                    ParentId = system.Id,
                    Name = "角色授权",
                    Url = "/Role/Authen",
                    AddTime = _now,
                    Order = 4,
                    Type = 2
                }; //6
                var sysConfig = new Menu
                {
                    ParentId = system.Id,
                    Name = "系统配置",
                    Url = "/System/Index",
                    AddTime = _now,
                    Order = 4,
                    Type = 2
                }; //7
                var sysConfigReloadPathCode = new Menu
                {
                    ParentId = sysConfig.Id,
                    Name = "重置路径码",
                    Url = "/System/ReloadPathCode",
                    AddTime = _now,
                    Order = 1,
                    Type = 3
                }; //8
                var log = new Menu
                {
                    
                    Name = "日志查看",
                    Url = "#",
                    Icon = "fa fa-table",
                    AddTime = _now,
                    Order = 9,
                    Type = 1
                }; //9
                var logLogin = new Menu
                {
                    
                    ParentId = log.Id,
                    Name = "登录日志",
                    Url = "/Log/Logins",
                    AddTime = _now,
                    Order = 9,
                    Type = 2
                }; //10
                var logView = new Menu
                {
                    
                    ParentId = log.Id,
                    Name = "访问日志",
                    Url = "/Log/Visits",
                    AddTime = _now,
                    Order = 10,
                    Type = 2
                }; //11

                var logChart = new Menu
                {
                    
                    ParentId = log.Id,
                    Name = "图表统计",
                    Url = "/Log/Charts",
                    AddTime = _now,
                    Order = 11,
                    Type = 2
                };
                var userRoleSet = new Menu
                {
                    
                    ParentId = userRoleMgr.Id,
                    Name = "用户角色授权",
                    Url = "/User/GiveRight",
                    AddTime = _now,
                    Order = 4,
                    Type = 3
                };
                var userRoleCancel = new Menu
                {
                    
                    ParentId = userRoleMgr.Id,
                    Name = "用户角色取消",
                    Url = "/User/CancelRight",
                    AddTime = _now,
                    Order = 4,
                    Type = 3
                };


                //运营管理
                var operation = new Menu
                {
                    
                    Name = "运营管理",
                    Url = "#",
                    Icon = "fa fa-desktop",
                    AddTime = _now,
                    Order = 2,
                    Type = 1
                };

                //用户管理
                var account = new Menu
                {
                    
                    ParentId = operation.Id,
                    Name = "用户管理",
                    Url = "/Account/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //车辆管理
                var vehicle = new Menu
                {
                    
                    ParentId = operation.Id,
                    Name = "车辆管理",
                    Url = "/Vehicle/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //货源管理
                var supply = new Menu
                {
                    
                    ParentId = operation.Id,
                    Name = "货源管理",
                    Url = "/Supply/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //订单管理
                var order = new Menu
                {
                    
                    Name = "订单管理",
                    Url = "#",
                    Icon = "fa fa-sitemap",
                    AddTime = _now,
                    Order = 2,
                    Type = 1
                };

                //订单列表
                var orders = new Menu
                {
                    
                    ParentId = order.Id,
                    Name = "订单列表",
                    Url = "/Order/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //在途跟踪
                var tracking = new Menu
                {
                    
                    ParentId = order.Id,
                    Name = "在途跟踪",
                    Url = "/Tracking/Index",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //资金管理
                var money = new Menu
                {
                    
                    Name = "资金管理",
                    Url = "#",
                    Icon = "fa fa-windows",
                    AddTime = _now,
                    Order = 2,
                    Type = 1
                };

                //统计分析
                var charts = new Menu
                {
                    
                    Name = "统计分析",
                    Url = "#",
                    Icon = "fa fa-bar-chart-o",
                    AddTime = _now,
                    Order = 2,
                    Type = 1
                };

                //订单统计
                var orderChart = new Menu
                {
                    
                    ParentId = charts.Id,
                    Name = "订单统计",
                    Url = "/Chart/Order",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //货源统计
                var supplyChart = new Menu
                {
                    
                    ParentId = charts.Id,
                    Name = "货源统计",
                    Url = "/Chart/Supply",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //用户统计
                var accountChart = new Menu
                {
                    
                    ParentId = charts.Id,
                    Name = "用户统计",
                    Url = "/Chart/Account",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };

                //车辆统计
                var vehicleChart = new Menu
                {
                    
                    ParentId = charts.Id,
                    Name = "车辆统计",
                    Url = "/Chart/Vehicle",
                    AddTime = _now,
                    Order = 2,
                    Type = 2
                };




                //菜单
                var menus = new List<Menu>
                {
                    system,
                    menuMgr,
                    departmentMgr,
                    roleMgr,
                    userMgr,
                    userRoleMgr,
                    userRoleSet,
                    userRoleCancel,
                    roleMenuMgr,
                    sysConfig,
                    sysConfigReloadPathCode,
                    log,
                    logLogin,
                    logView,
                    logChart,

                    operation,
                    account,
                    vehicle,
                    supply,
                    order,
                    orders,
                    tracking,
                    money,
                    charts,
                    orderChart,
                    supplyChart,
                    accountChart,
                    vehicleChart
                };
                var menuBtns = GetMenuButtons(menuMgr.Id, "Menu", "菜单"); //14
                var rolwBtns = GetMenuButtons(roleMgr.Id, "Role", "角色"); //17
                var userBtns = GetMenuButtons(userMgr.Id, "User", "用户"); //20
                var departmentBtns = GetMenuButtons(departmentMgr.Id, "Department", "部门");

                var accountBtns = GetMenuButtons(account.Id, "Account", "用户");

                menus.AddRange(menuBtns); //14
                menus.AddRange(rolwBtns); //17
                menus.AddRange(userBtns); //20
                menus.AddRange(departmentBtns);

                menus.AddRange(accountBtns);

                menus.Add(new Menu
                {
                    
                    ParentId = roleMenuMgr.Id,
                    Order = 6,
                    Name = "授权",
                    Type = 3,
                    Url = "/Role/SetRoleMenus",
                    AddTime = _now,
                });
                menus.Add(new Menu
                {
                    
                    ParentId = roleMenuMgr.Id,
                    Order = 6,
                    Name = "清空权限",
                    Type = 3,
                    Url = "/Role/ClearRoleMenus",
                    AddTime = _now,
                });

                #endregion

                #region 角色

                var superAdminRole = new Role
                {
                    
                    Name = "超级管理员",
                    Description = "超级管理员",
                    Menus = menus
                };
                var guestRole = new Role
                {
                    
                    Name = "guest",
                    Description = "游客",
                    Menus = menus.Where(x => x.Type != 3).ToList()
                };
                var roles = new List<Role>
                {
                    superAdminRole,
                    guestRole
                };

                #endregion

                #region 用户

                var admin = new User
                {
                    
                    Username = "admin",
                    NickName = "超级管理员",
                    Password = "111111".Md5HashEncrypt(),
                    Email = "service@lgiotchina.com",
                    IsSuperMan = true,
                    AddTime = _now,
                    Roles = new List<Role> { superAdminRole }
                };

                var guest = new User
                {

                    Username = "clark",
                    NickName = "游客",
                    Password = "111111".Md5HashEncrypt(),
                    Email = "service@lgiotchina.com",
                    AddTime = _now,
                    Roles = new List<Role> { guestRole }
                };

                var jucheap = new User
                {

                    Username = "jucheap",
                    NickName = "游客",
                    Password = "qwaszx..".Md5HashEncrypt(),
                    Email = "service@lgiotchina.com",
                    IsSuperMan = true,
                    AddTime = _now,
                    Roles = new List<Role> { superAdminRole }
                };
                //用户
                var user = new List<User>
                {
                    admin,
                    guest,
                    jucheap
                };

                #endregion

                //AddOrUpdate(context, m => m.Username, user.ToArray());
                //AddOrUpdate(context, m => new { m.ParentId, m.Name }, menus.ToArray());
                //AddOrUpdate(context, m => m.Name, roles.ToArray());


            base.Seed(context);
        }

        #region Private

        /// <summary>
        /// 获取菜单的基础按钮
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="controllerShowName">菜单显示名称</param>
        /// <param name="btnStr">需要显示的按钮,1显示0不显示</param>
        /// <returns></returns>
        private IEnumerable<Menu> GetMenuButtons(Guid parentId, string controllerName, string controllerShowName, string btnStr = "1111")
        {
            var btnName = new[] { "添加", "修改", "删除", "查看" };
            var btnUrl = new[] { "Add", "Edit", "Delete", "Detail" };
            var btns = new List<Menu>();
            var arr = btnStr.Select(x => int.Parse(x.ToString())).ToArray();
            var i = 0;
            arr.ForEach(m =>
            {
                if (m == 1)
                {
                    btns.Add(new Menu
                    {
                        ParentId = parentId,
                        Name = string.Concat(btnName[i], controllerShowName),
                        Url = $"/{controllerName}/{btnUrl[i]}",
                        AddTime = _now,
                        Order = i + 1,
                        Type = 3
                    });
                }
                i++;
            });

            return btns;
        }

        /// <summary>
        /// 添加更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="exp"></param>
        /// <param name="param"></param>
        void AddOrUpdate<T>(DbContext context, Expression<Func<T, object>> exp, T[] param) where T : class
        {
            var set = context.Set<T>();
            set.AddOrUpdate(exp, param);
        }


        //class MyCodeGenerator : MySql.Data.Entity.MySqlMigrationSqlGenerator
        //{
        //    public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations,
        //        string providerManifestToken)
        //    {
        //        IEnumerable<MigrationStatement> res = base.Generate(migrationOperations, providerManifestToken);
        //        foreach (MigrationStatement ms in res)
        //        {
        //            ms.Sql = ms.Sql.Replace("dbo.", "");
        //        }
        //        return res;
        //    }
        //}

        #endregion
    }
}
