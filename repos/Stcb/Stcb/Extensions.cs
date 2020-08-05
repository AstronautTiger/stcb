using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Stcb
{
    public static class Extensions
    {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IDictionary dict, Func<DictionaryEntry, TKey> keyConverter, Func<DictionaryEntry, TValue> valueConverter)
        {
            Dictionary<TKey, TValue> retval = new Dictionary<TKey, TValue>();
            foreach (DictionaryEntry entry in dict)
            {
                retval.TryAdd(keyConverter(entry), valueConverter(entry));
            }

            return retval;
        }

        public static TObject Get<TObject>(this object obj, string propertyName)
        {
            var memberInfo = obj.GetType().GetMember(propertyName, MemberTypes.All,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).FirstOrDefault();

            if (memberInfo == null) return default;

            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return (TObject)((FieldInfo)memberInfo).GetValue(obj);
                case MemberTypes.Property:
                    return (TObject)((PropertyInfo)memberInfo).GetValue(obj);
            }

            return default;
        }

    }
}