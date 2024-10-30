using Oracle.ManagedDataAccess.Types;

namespace NetSdoGeometry
{
    [OracleCustomTypeMapping("MDSYS.SDO_ELEM_INFO_ARRAY")]
    public class ElemArrayFactory : OracleArrayTypeFactoryBase<decimal>
    {
    }
}
