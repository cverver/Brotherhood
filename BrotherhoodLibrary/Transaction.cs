namespace BrotherhoodLibrary {
    using System;
    using System . Collections . Generic;
    using System . ComponentModel . DataAnnotations;
    using System . ComponentModel . DataAnnotations . Schema;
    using System . Data . Entity . Spatial;

    public partial class Transaction {
        [Key]
        [Column ( Order = 0 )]
        [DatabaseGenerated ( DatabaseGeneratedOption . Identity )]
        public Int64 ID { get; set; }

        [Key]
        [Column ( Order = 1 )]
        [DatabaseGenerated ( DatabaseGeneratedOption . None )]
        public Int64 AccountID { get; set; }

        public Int64 Amount { get; set; }

        public virtual Account Account { get; set; }
    }
}
