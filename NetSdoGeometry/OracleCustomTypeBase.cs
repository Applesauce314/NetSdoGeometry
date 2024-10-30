using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System;
using System.Globalization;

namespace NetSdoGeometry
{

    [Serializable]
    public abstract class OracleCustomTypeBase<T> : INullable, IOracleCustomType, IOracleCustomTypeFactory
    where T : OracleCustomTypeBase<T>, new()
    {
        private static readonly string _errorMessageHead = "Error converting Oracle User Defined Type to .Net Type " + typeof(T).ToString() + ", oracle column is null, failed to map to . NET valuetype, column ";

        [NonSerialized]
        private OracleConnection? connection;

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

        public void FromCustomObject(OracleConnection con, object udt)
        {
            this.SetConnectionAndPointer(con, udt);
            this.MapFromCustomObject();
        }

        public void ToCustomObject(OracleConnection con, object udt)
        {
            this.SetConnectionAndPointer(con, udt);
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

        protected TValue? GetValue<TValue>(string oracleColumnName)
        {
            ArgumentNullException.ThrowIfNull(oracleColumnName);
            if (OracleUdt.IsDBNull(this.connection, this.udtObject, oracleColumnName))
            {
                if (default(TValue) is ValueType)
                {
                    throw new InvalidOperationException(_errorMessageHead + oracleColumnName.ToString() + " of value type " + typeof(TValue).ToString());
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return (TValue)OracleUdt.GetValue(this.connection, this.udtObject, oracleColumnName);
            }
        }

        protected TValue? GetValue<TValue>(int oracleColumnId)
        {
            if (OracleUdt.IsDBNull(this.connection, this.udtObject, oracleColumnId))
            {
                if (default(TValue) is ValueType)
                {
                    throw new InvalidOperationException(_errorMessageHead + oracleColumnId.ToString(CultureInfo.InvariantCulture) + " of value type " + typeof(TValue).ToString());
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return (TValue)OracleUdt.GetValue(this.connection, this.udtObject, oracleColumnId);
            }
        }
    }
}