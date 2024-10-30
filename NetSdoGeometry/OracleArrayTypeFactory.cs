using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System;

namespace NetSdoGeometry
{

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