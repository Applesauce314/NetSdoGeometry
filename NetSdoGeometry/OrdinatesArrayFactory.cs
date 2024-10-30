using Oracle.ManagedDataAccess.Types;

namespace NetSdoGeometry
{
    [OracleCustomTypeMapping("MDSYS.SDO_ORDINATE_ARRAY")]
    public class OrdinatesArrayFactory : OracleArrayTypeFactoryBase<decimal>
    {
    }
}
