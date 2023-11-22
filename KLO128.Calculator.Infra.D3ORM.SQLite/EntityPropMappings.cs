

//
// generated file 26.10.2023 18:46:27
//

using KLO128.D3ORM.Common.Models;
using KLO128.Calculator.Domain.Models.Entities;

namespace KLO128.Calculator.Infra.D3ORM.SQLite
{
    public static class EntityPropMappings
    {
        public static Dictionary<Type, EntityMapping> Dict { get; } = new Dictionary<Type, EntityMapping>
        {

            {
                typeof(CalcEntry),
                new EntityMapping
                {
                    Entity = "CalcEntry",
                    Table = "[CalcEntry]",
                    PrimaryKeyPropName = "CalcEntryId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "CalcHistoryId", "CalcHistory, <->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "CalcEntryId",
                            new PropertyMapping
                            {
                                Property = "CalcEntryId",
                                DbColumn = "[CalcEntryId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.CalcEntryId))!
                            }
                        },

                        { 
                            "CalcHistoryId",
                            new PropertyMapping
                            {
                                Property = "CalcHistoryId",
                                DbColumn = "[CalcHistoryId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.CalcHistoryId))!
                            }
                        },

                        { 
                            "Expression",
                            new PropertyMapping
                            {
                                Property = "Expression",
                                DbColumn = "[Expression]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.Expression))!
                            }
                        },

                        { 
                            "Result",
                            new PropertyMapping
                            {
                                Property = "Result",
                                DbColumn = "[Result]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.Result))!
                            }
                        },

                        { 
                            "ErrorCode",
                            new PropertyMapping
                            {
                                Property = "ErrorCode",
                                DbColumn = "[ErrorCode]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.ErrorCode))!
                            }
                        },

                        { 
                            "ErrorArgs",
                            new PropertyMapping
                            {
                                Property = "ErrorArgs",
                                DbColumn = "[ErrorArgs]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.ErrorArgs))!
                            }
                        },

                        { 
                            "CreatedDate",
                            new PropertyMapping
                            {
                                Property = "CreatedDate",
                                DbColumn = "[CreatedDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.CreatedDate))!
                            }
                        },

                        { 
                            "CalcHistory",
                            new PropertyMapping
                            {
                                Property = "CalcHistory",
                                DbColumn = "[CalcHistory]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(CalcEntry).GetProperty(nameof(CalcEntry.CalcHistory))!
                            }
                        }
                    }
                }
            },
            {
                typeof(CalcHistory),
                new EntityMapping
                {
                    Entity = "CalcHistory",
                    Table = "[CalcHistory]",
                    PrimaryKeyPropName = "CalcHistoryId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "CalcHistoryId",
                            new PropertyMapping
                            {
                                Property = "CalcHistoryId",
                                DbColumn = "[CalcHistoryId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.CalcHistoryId))!
                            }
                        },

                        { 
                            "Guid",
                            new PropertyMapping
                            {
                                Property = "Guid",
                                DbColumn = "[Guid]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.Guid))!
                            }
                        },

                        { 
                            "AccessToken",
                            new PropertyMapping
                            {
                                Property = "AccessToken",
                                DbColumn = "[AccessToken]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.AccessToken))!
                            }
                        },

                        { 
                            "NameToDisplay",
                            new PropertyMapping
                            {
                                Property = "NameToDisplay",
                                DbColumn = "[NameToDisplay]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.NameToDisplay))!
                            }
                        },

                        { 
                            "CreatedDate",
                            new PropertyMapping
                            {
                                Property = "CreatedDate",
                                DbColumn = "[CreatedDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.CreatedDate))!
                            }
                        },

                        { 
                            "UpdatedDate",
                            new PropertyMapping
                            {
                                Property = "UpdatedDate",
                                DbColumn = "[UpdatedDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.UpdatedDate))!
                            }
                        },

                        { 
                            "CalcEntries",
                            new PropertyMapping
                            {
                                Property = "CalcEntries",
                                DbColumn = "[CalcEntries]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(CalcHistory).GetProperty(nameof(CalcHistory.CalcEntries))!
                            }
                        }
                    }
                }
            }
        };
    }
}


