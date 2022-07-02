using System.Reflection;
using Dapper;
using Database.Models;

namespace Database;

/* https://dev.to/yorek/dapper-net-custom-columns-mapping-ka4 */
public static class MappingRules {
    private static readonly Dictionary<string, string> _columnMaps = new()
    {
        /* column -> bo property */
        {"build_id", "Id"}
    };

    public static void SetRules()
    {
        var mapper = new Func<Type, string, PropertyInfo?>((type, columnName) =>
        {
            if (_columnMaps.ContainsKey(columnName))
                return type.GetProperty(_columnMaps[columnName]);
            else
                return type.GetProperty(columnName);
        });
        
        var buildMap = new CustomPropertyTypeMap(
            typeof(BuildBO), (type, columnName) => mapper(type, columnName));
        
        SqlMapper.SetTypeMap(typeof(BuildBO), buildMap);
    }
}