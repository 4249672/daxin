using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public static class EnumExtensions
    {
        private static ConcurrentDictionary<Enum, string> _concurrentDictionary = new ConcurrentDictionary<Enum, string>();
        private static ConcurrentDictionary<Type, Dictionary<string, string>> _concurrentDicDictionary = new ConcurrentDictionary<Type, Dictionary<string, string>>();
        /// <summary>
        /// 锁对象
        /// </summary>
        private static object objLock = new object();

        /// <summary>
        /// 获取枚举的描述信息(Descripion)。
        /// 支持位域，如果是位域组合值，多个按分隔符组合。
        /// </summary>
        public static string GetDescription(this Enum @this)
        {
            return _concurrentDictionary.GetOrAdd(@this, (key) =>
            {
                var type = key.GetType();
                var field = type.GetField(key.ToString());
                //如果field为null则应该是组合位域值，
                return field == null ? key.GetDescriptions() : GetDescription(field);
            });
        }
        /// <summary>
        /// 获取枚举的说明
        /// </summary>
        /// <param name="split">位枚举的分割符号（仅对位枚举有作用）</param>
        private static string GetDescriptions(this Enum em, string split = ",")
        {
            var names = em.ToString().Split(',');
            string[] res = new string[names.Length];
            var type = em.GetType();
            for (int i = 0; i < names.Length; i++)
            {
                var field = type.GetField(names[i].Trim());
                if (field == null) continue;
                res[i] = GetDescription(field);
            }
            return string.Join(split, res);
        }
        private static string GetDescription(FieldInfo field)
        {
            var att = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
            return att == null ? field.Name : ((DescriptionAttribute)att).Description;
        }

        /// <summary>
        /// 根据Enum类型 获取字段的描述 , 比如  EnumType.B.ToString()
        /// </summary>
        /// <param name="typeEm">Enum 类型 EnumType</param>
        /// <param name="emVal">字段的名称 B</param>
        /// <returns></returns>
        public static string GetDescription(this Type typeEm, string emVal)
        {
            if (string.IsNullOrEmpty(emVal) || !typeEm.IsEnum)
                return "";
            var list = GetEunItemValueAndDesc(typeEm);
            list.TryGetValue(emVal, out string output);
            return output;
        }


        /// <summary>
        /// 把枚举转换成为列表
        /// </summary>
        public static List<EnumObject> ToList(this Type type)
        {
            List<EnumObject> list = new List<EnumObject>();
            foreach (object obj in Enum.GetValues(type))
            {
                list.Add(new EnumObject((Enum)obj));
            }
            return list;
        }

        ///<summary>  
        /// 获取枚举值+描述  
        ///</summary>  
        ///<param name="enumType">Type,该参数的格式为typeof(需要读的枚举类型)</param>  
        ///<returns>键值对</returns>  
        private static Dictionary<string, string> GetEnumItemValueDesc(Type enumType)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        strText = aa.Description;
                    }
                    else
                    {
                        strText = field.Name;
                    }
                    //dic.Add(strValue, strText);
                    dic.Add(field.Name, strText); //这里使用 类型 EnunType.B 中的 B , 而不是直接用 B代表的数字值
                }
            }
            return dic;
        }

        /// <summary>
        /// 获取枚举类型键值对
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetEunItemValueAndDesc(Type em)
        {
            return _concurrentDicDictionary.GetOrAdd(em, (key) =>
            {
                var type = key.GetType();
                if (_concurrentDicDictionary.ContainsKey(key))
                    return _concurrentDicDictionary[key];
                else
                    return GetEnumItemValueDesc(em);
            });
        }
    }

    public struct EnumObject
    {
        public EnumObject(Enum um, string picture = null)
        {
            this.ID = (int)Convert.ChangeType(um, typeof(int));
            this.Name = um.ToString();
            this.Description = um.GetDescription();
            this.Picture = picture;
        }

        public EnumObject(int id, string name)
        {
            this.ID = id;
            this.Name = this.Description = name;
            this.Picture = null;
        }

        public EnumObject(int id, string name, string description, string picture)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Picture = picture;
        }

        public int ID;

        public string Name;

        public string Description;

        public string Picture;
    }
}
