using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXInfo.Models;
using System.Web.Security;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
namespace ynhnTransportManage
{
    public class Helpers
    {
        public static IEnumerable<SelectListItem> GetDepts()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var depts = from d in contex.Depts 
                        orderby d.DeptCode
                        select d;
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Dept dept in depts.ToList<Dept>())
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Text = dept.DeptName;
                listItem.Value = dept.DeptId.ToString();
                listItems.Add(listItem);
            }
            return listItems;
        }
        public static IEnumerable<SelectListItem> GetVehicle()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var vehicles = contex.Vehicles.ToList();
            var listItems =
                from v in vehicles
                select
                    new SelectListItem()
                    {
                        Text = v.PlateNo,
                        Value = v.Id.ToString()
                    };
            return listItems;
        }
        public static IEnumerable<SelectListItem> GetInv()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var vehicles = contex.Inventory.ToList();
            var listItems =
                (from v in vehicles
                select
                    new SelectListItem()
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    }).ToList<SelectListItem>();
            listItems.Insert(0, new SelectListItem() { Text = "", Value = "" });
            return listItems;
        }
        public static IEnumerable<SelectListItem> GetUsers()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var users = contex.aspnet_CustomProfile.ToList();
            var listItems =
                (from v in users
                select
                    new SelectListItem()
                    {
                        Text = v.FullName,
                        Value = v.UserId.ToString()
                    }).ToList<SelectListItem>();
            listItems.Insert(0, new SelectListItem() { Text = "", Value = "" });
            return listItems;
        }

        public static IEnumerable<SelectListItem> GetBalanceType()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var users = contex.NameCode.Where(w=>w.Type=="BalanceType").ToList();
            var listItems =
                from v in users
                select
                    new SelectListItem()
                    {
                        Text = v.Name,
                        Value = v.ID.ToString()
                    };
            return listItems;
        }
        public static IEnumerable<SelectListItem> GetLines()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var users = contex.Lines.ToList();
            var listItems =
                (from v in users
                select
                    new SelectListItem()
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()                        
                    }).ToList<SelectListItem>();
            listItems.Insert(0, new SelectListItem() { Text = "", Value = "" });
            return listItems;
        }
        public static IEnumerable<SelectListItem> GetDrivers()
        {
            DXInfo.Models.ynhnTransportManage contex = new DXInfo.Models.ynhnTransportManage();
            var users = contex.Drivers.ToList();
            var listItems =
                from v in users
                select
                    new SelectListItem()
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    };
            return listItems;
        }
        public static IEnumerable<string> GetAllSitemapKeys(HttpContextBase context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                DXInfo.Models.ynhnTransportManage db = new DXInfo.Models.ynhnTransportManage();
                MembershipUser user = Membership.GetUser();
                Guid userId = Guid.Parse(user.ProviderUserKey.ToString());
                //List<Guid> roleids = db.aspnet_UsersInRoles.Where(w => w.UserId == userId).Select(s => s.RoleId).ToList<Guid>();
                //string[] roles = Roles.GetRolesForUser();
                //string role = "";
                //foreach (string str in roles)
                //{
                //    role += "'" + str + "',";
                //}
                //role = role.Substring(0, role.Length - 1);
                //var ruleforrole = (from a in db.aspnet_AuthorizationRules where roleids.Contains(a.RoleId) select a.SiteMapKey).ToList();

                var ruleforrole = (from a in db.aspnet_AuthorizationRules
                                   join b in db.aspnet_UsersInRoles.Where(w => w.UserId == userId) on a.RoleId equals b.RoleId
                                   select a.SiteMapKey).ToList();
                //var ruleforuser = (from a in db.aspnet_AuthorizationRules where a.UserName == context.User.Identity.Name select a.SiteMapKey).ToList();
                var ruleforuser = (from a in db.aspnet_AuthorizationRules.Where(w => w.UserId == userId)
                                   select a.SiteMapKey).ToList();
                return ruleforrole.Concat(ruleforuser);
            }
            return null;
        }

        public static DataTable LinqToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }

    /// <summary>
    /// 类属性/字段的值复制工具
    /// </summary>
    public class ClassValueCopier
    {
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return Copy(destination, source, source.GetType());
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type)
        {
            return Copy(destination, source, type, null);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="destination">目标</param>
        /// <param name="source">来源</param>
        /// <param name="type">复制的属性字段模板</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int Copy(object destination, object source, Type type, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            if (excludeName == null)
            {
                excludeName = new List<string>();
            }
            int i = 0;
            Type desType = destination.GetType();
            foreach (FieldInfo mi in type.GetFields())
            {
                if (excludeName.Contains(mi.Name))
                {
                    continue;
                }
                try
                {
                    FieldInfo des = desType.GetField(mi.Name);
                    if (des != null && des.FieldType == mi.FieldType)
                    {
                        des.SetValue(destination, mi.GetValue(source));
                        i++;
                    }

                }
                catch
                {
                }
            }

            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (excludeName.Contains(pi.Name))
                {
                    continue;
                }
                try
                {
                    PropertyInfo des = desType.GetProperty(pi.Name);
                    if (des != null && des.PropertyType == pi.PropertyType && des.CanWrite && pi.CanRead)
                    {
                        des.SetValue(destination, pi.GetValue(source, null), null);
                        i++;
                    }

                }
                catch
                {
                    //throw ex;
                }
            }
            return i;
        }
    }


    #region 扩展方法 For .NET 3.0+
    /// <summary>
    /// 类属性/字段的值复制工具 扩展方法
    /// </summary>
    public static class ClassValueCopier2
    {
        /// <summary>
        /// 获取实体类的属性名称
        /// </summary>
        /// <param name="source">实体类</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this object source)
        {
            if (source == null)
            {
                return new List<string>();
            }
            return GetPropertyNames(source.GetType());
        }
        /// <summary>
        /// 获取类类型的属性名称（按声明顺序）
        /// </summary>
        /// <param name="source">类类型</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this Type source)
        {
            return GetPropertyNames(source, true);
        }
        /// <summary>
        /// 获取类类型的属性名称
        /// </summary>
        /// <param name="source">类类型</param>
        /// <param name="declarationOrder">是否按声明顺序排序</param>
        /// <returns>属性名称列表</returns>
        public static List<string> GetPropertyNames(this Type source, bool declarationOrder)
        {
            if (source == null)
            {
                return new List<string>();
            }
            var list = source.GetProperties().AsQueryable();
            if (declarationOrder)
            {
                list = list.OrderBy(p => p.MetadataToken);
            }
            return list.Select(o => o.Name).ToList(); ;
        }

        /// <summary>
        /// 从源对象赋值到当前对象
        /// </summary>
        /// <param name="destination">当前对象</param>
        /// <param name="source">源对象</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueFrom(this object destination, object source)
        {
            return CopyValueFrom(destination, source, null);
        }

        /// <summary>
        /// 从源对象赋值到当前对象
        /// </summary>
        /// <param name="destination">当前对象</param>
        /// <param name="source">源对象</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueFrom(this object destination, object source, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return ClassValueCopier.Copy(destination, source, source.GetType(), excludeName);
        }

        /// <summary>
        /// 从当前对象赋值到目标对象
        /// </summary>
        /// <param name="source">当前对象</param>
        /// <param name="destination">目标对象</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueTo(this object source, object destination)
        {
            return CopyValueTo(destination, source, null);
        }

        /// <summary>
        /// 从当前对象赋值到目标对象
        /// </summary>
        /// <param name="source">当前对象</param>
        /// <param name="destination">目标对象</param>
        /// <param name="excludeName">排除下列名称的属性不要复制</param>
        /// <returns>成功复制的值个数</returns>
        public static int CopyValueTo(this object source, object destination, IEnumerable<string> excludeName)
        {
            if (destination == null || source == null)
            {
                return 0;
            }
            return ClassValueCopier.Copy(destination, source, source.GetType(), excludeName);
        }

    }
    #endregion
}