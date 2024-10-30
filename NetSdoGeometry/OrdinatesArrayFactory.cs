using Oracle.ManagedDataAccess.Types;

namespace NetSdoGeometry
{
    [OracleCustomTypeMappingAttribute("MDSYS.SDO_ORDINATE_ARRAY")]
    public class OrdinatesArrayFactory : OracleArrayTypeFactoryBase<decimal>
    {
    }
}
