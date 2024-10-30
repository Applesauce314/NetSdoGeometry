using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System;

namespace NetSdoGeometry
{


    [Serializable]
    public abstract class OracleCustomTypeBase<T> : INullable, IOracleCustomType, IOracleCustomTypeFactory
    where T : OracleCustomTypeBase<T>, new()
    {
        private static string errorMessageHead = "Error converting Oracle User Defined Type to .Net Type " + typeof(T).ToString() + ", oracle column is null, failed to map to . NET valuetype, column ";

        [NonSerialized]
        private OracleConnection connection;

        private object? udtObject;

        private bool isNull;

        public static T Null
        {
            get
            {
                T t = new T
                {
                    isNull = true
                };
                return t;
            }
        }

        public virtual bool IsNull => this.isNull;

        public IOracleCustomType CreateObject()
        {
            return new T();
        }

        public void FromCustomObject(OracleConnection connection, object udt)
        {
            this.SetConnectionAndPointer(connection, udt);
            this.MapFromCustomObject();
        }

        public void ToCustomObject(OracleConnection connection, object udt)
        {
            this.SetConnectionAndPointer(connection, udt);
            this.MapToCustomObject();
        }

        public abstract void MapFromCustomObject();

        public abstract void MapToCustomObject();

        protected void SetConnectionAndPointer(OracleConnection connection, object udt)
        {
            this.connection = connection;
            this.udtObject = udt;
        }

        protected void SetValue(string oracleColumnName, object? value)
        {
            if (value != null)
            {
                OracleUdt.SetValue(this.connection, this.udtObject, oracleColumnName, value);
            }
        }

        protected void SetValue(int oracleColumnId, object? value)
        {
            if (value != null)
            {
                OracleUdt.SetValue(this.connection, this.udtObject, oracleColumnId, value);
            }
        }

        protected U? GetValue<U>(string oracleColumnName)
        {
            if (OracleUdt.IsDBNull(this.connection, this.udtObject, oracleColumnName))
            {
                if (default(U) is ValueType)
                {
                    throw new Exception(errorMessageHead + oracleColumnName.ToString() + " of value type " + typeof(U).ToString());
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return (U)OracleUdt.GetValue(this.connection, this.udtObject, oracleColumnName);
            }
        }

        protected U? GetValue<U>(int oracleColumnId)
        {
            if (OracleUdt.IsDBNull(this.connection, this.udtObject, oracleColumnId))
            {
                if (default(U) is ValueType)
                {
                    throw new Exception(errorMessageHead + oracleColumnId.ToString() + " of value type " + typeof(U).ToString());
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return (U)OracleUdt.GetValue(this.connection, this.udtObject, oracleColumnId);
            }
        }
    }
}