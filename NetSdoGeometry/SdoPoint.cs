using Oracle.ManagedDataAccess.Types;

using System;
using System.Globalization;

namespace NetSdoGeometry
{


    [Serializable]
    [OracleCustomTypeMapping("MDSYS.SDO_POINT_TYPE")]
    public class SdoPoint : OracleCustomTypeBase<SdoPoint>
    {
        [OracleObjectMapping("X")]
        public decimal? X { get; set; }

        [OracleObjectMapping("Y")]
        public decimal? Y { get; set; }

        [OracleObjectMapping("Z")]
        public decimal? Z { get; set; }

        public double? XD
        {
            get => System.Convert.ToDouble(this.X, CultureInfo.InvariantCulture);
            set => this.X = System.Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public double? YD
        {
            get => System.Convert.ToDouble(this.Y, CultureInfo.InvariantCulture);
            set => this.Y = System.Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public double? ZD
        {
            get => System.Convert.ToDouble(this.Z, CultureInfo.InvariantCulture);
            set => this.Z = System.Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public override void MapFromCustomObject()
        {
            this.SetValue("X", this.X);
            this.SetValue("Y", this.Y);
            this.SetValue("Z", this.Z);
        }

        public override void MapToCustomObject()
        {
            this.X = this.GetValue<decimal?>("X");
            this.Y = this.GetValue<decimal?>("Y");
            this.Z = this.GetValue<decimal?>("Z");
        }
    }
}
