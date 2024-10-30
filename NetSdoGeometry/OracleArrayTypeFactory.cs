using Oracle.ManagedDataAccess.Types;

namespace NetSdoGeometry
{
    using System;

    public abstract class OracleArrayTypeFactoryBase<T> : IOracleArrayTypeFactory
    {
        public Array CreateArray(int numElems)
        {
            return new T[numElems];
        }

        public Array CreateStatusArray(int numElems)
        {
            return new OracleUdtStatus[numElems];
        }
    }
}