using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取类型成员的注释
        /// </summary>
        /// <param name="data"></param>
        /// <returns>注释,如果无注释则返回成员名</returns>
        public static string GetDescription(this Enum data)
        {
            string name = data.ToString();
            MemberInfo[] members = data.GetType().GetMember(name);
            foreach (MemberInfo member in members)
            {
                if (member.Name == name)
                {
                    foreach (DescriptionAttribute attr in member.GetCustomAttributes(typeof(DescriptionAttribute), false))
                    {
                        return attr.Description;
                    }
                }
            }
            return name;
        }
        /// <summary>
        /// 获取类型成员的注释
        /// </summary>
        /// <param name="aType">类型定义</param>
        /// <param name="aName">成员名</param>
        /// <returns>注释,如果无注释则返回成员名</returns>
        public static string GetDescription(this Type aType, string aName)
        {
            if (string.IsNullOrEmpty(aName)) return string.Empty;
            MemberInfo[] members = aType.GetMember(aName);
            foreach (MemberInfo member in members)
            {
                foreach (DescriptionAttribute attr in member.GetCustomAttributes(typeof(DescriptionAttribute), false))
                {
                    return attr.Description;
                }
            }
            return aName;
        }
        /// <summary>
        /// 获取类型中所有属性的Description
        /// </summary>
        /// <param name="aType">类型定义</param>
        /// <returns></returns>
        public static List<string> GetDescriptions(this Type aType)
        {
            List<string> comments = new List<string>();
            if (aType.IsEnum)
            {
                string[] names = Enum.GetNames(aType);
                foreach (string name in names)
                {
                    comments.Add(aType.GetDescription(name));
                }
            }
            else if (aType.IsClass)
            {
                foreach (FieldInfo field in aType.GetFields())
                {
                    foreach (DescriptionAttribute attr in field.GetCustomAttributes(typeof(DescriptionAttribute), false))
                    {
                        comments.Add(attr.Description);
                    }
                }
            }
            return comments;
        }
    }
}
