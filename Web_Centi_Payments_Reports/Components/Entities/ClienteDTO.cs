using System.ComponentModel.DataAnnotations;

namespace Web_Centi_Payments_Reports.Components.Entities
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string NombreCompleto { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int IdDepartamento { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int Sueldo { get; set; }

        public DateTime FechaContrato { get; set; }

        //public DepartamentoDTO? Departamento { get; set; }
    }
    public class ClienteInfo
    {        
        public int _IdCuenta { get; set; }
        public int _IdOperacion { get; set; }
        public string _Cic { get; set; } = null!;
        public string _NroCredito { get; set; } = null!;
        public string _Moneda { get; set; } = null!;
        public decimal _Monto { get; set; }//MontoTotal
        public decimal _MontoProcesado { get; set; }
        public decimal _MontoRestante { get; set; }
        public decimal _Pendiente { get; set; }
        public decimal _MontoDeudaCredito { get; set; }
        public decimal _MontoDebitar { get; set; }
        public decimal _TipoCambio { get; set; }
        public string _Glosa { get; set; } = null!;
        public string _CuentaDebito { get; set; } = null!;
        public string _CuentaDebitoMoneda { get; set; } = null!;
        public string _CuentaRepext { get; set; } = null!;
        public string _FechaReg { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string _TipoOperacion { get; set; } = null!;
        public string _EstadoOperacion { get; set; } = null!;
        // PARA LA FUNCIONALIDAD 4° --!> Aplicable para el tipo de cuenta Activa --!>
        public decimal _CodigoSituacion { get; set; } // CODIGO 35 -> CASTIGADA == CARTERA EN MORA CASTIGADA
        public string? _NombreSituacion { get; set; } // Esto significa que la propiedad puede contener un valor de tipo string o puede ser null.  
        public decimal _DiasMora { get; set; }
        public string _TipoCredito { get; set; } = null!;
        public string _calificacionProyectada { get; set; } = null!;
        public decimal _saldo { get; set; }
        // DATOS QUE SE MODIFICA EN EL SP REVISAR
        public int _Intentos { get; set; }
        public string _UltimoEstado { get; set; }
        public string _UltimoEstadoDesc { get; set; } = null!;
        public string _UltimaRespuesta { get; set; } = null!;
        public string _NroCreditoComercial { get; set; }
        public string _TipoCuentaDebito { get; set; } = null!;
        public string _NroCuentaDebitoRepext { get; set; }
        public decimal _MontoPago { get; set; }
    }
    public class CodeudorInfo
    {
        public string ID_OPERACION { get; set; }
        public string APLICATIVO { get; set; }
        public string CIC { get; set; }
        public string NOMBRE { get; set; }
        public string CUENTA_ALS { get; set; }
        public string CUENTA_DEBITO { get; set; }
        public string MONEDA { get; set; }
        public decimal MONTO { get; set; }
        public decimal SALDO { get; set; }
        public string GLOSA { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public string COD_EXTORNO { get; set; }
        public string idc_codeudor { get; set; }
    }
}
