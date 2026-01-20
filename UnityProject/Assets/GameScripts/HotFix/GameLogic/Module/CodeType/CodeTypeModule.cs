using System;
using System.Collections.Generic;
using System.Reflection;
using GameCore;

namespace GameLogic
{
    public class CodeTypeModule 
    {
        private readonly Dictionary<string, Type> allTypes = new Dictionary<string, Type>();
        private readonly Dictionary<Type, HashSet<Type>> types = new Dictionary<Type, HashSet<Type>>();
        public static Dictionary<string, Type> GetAssemblyTypes(params Assembly[] args)
        {
            Dictionary<string, Type> types = new Dictionary<string, Type>();

            foreach (Assembly ass in args)
            {
                foreach (Type type in ass.GetTypes())
                {
                    types[type.FullName] = type;
                }
            }

            return types;
        }
        
        public void Awake(Assembly[] assemblies)
        {
            Dictionary<string, Type> addTypes = GetAssemblyTypes(assemblies);
            foreach (var typeData in addTypes)
            {
                var fullName = typeData.Key;
                var type = typeData.Value;
                
                this.allTypes[fullName] = type;
                
                if (type.IsAbstract)
                {
                    continue;
                }
                
                // 记录所有的有BaseAttribute标记的的类型
                object[] objects = type.GetCustomAttributes(typeof(BaseAttribute), true);

                foreach (object o in objects)
                {
                    
                    var t = o.GetType();
                    HashSet<Type> set;
                    
                    types.TryGetValue(t, out set);
                    if (set == null)
                    {
                        set = new HashSet<Type>();
                        types[t] = set;
                    }
                    set.Add(type);
            
                    // this.types.Add(o.GetType(), type);
                }
            }
        }
        
        
        public HashSet<Type> GetTypes(Type systemAttributeType)
        {
            if (!types.ContainsKey(systemAttributeType))
            {
                return new HashSet<Type>();
            }

            return types[systemAttributeType];
        }
    }
}