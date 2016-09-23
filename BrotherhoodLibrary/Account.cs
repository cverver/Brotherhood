namespace BrotherhoodLibrary {
    using System;
    using System . Collections . Generic;
    using System . ComponentModel . DataAnnotations . Schema;

    public partial class Account {
        public Account ( ) {
            Transactions = new HashSet<Transaction> ( );
        }

        [DatabaseGenerated ( DatabaseGeneratedOption . Identity )]
        public Int64 ID { get; set; }//1

        public Int64 Balance { get; set; }//10

        public virtual ICollection<Transaction> Transactions { get; set; }

        public Int64 MakeTransaction ( Int64 To /*2*/ , UInt64 Amount /*5*/ ) {
            Int64 TransactionID;
            using ( BrotherhoodModel db = new BrotherhoodModel ( ) ) {
                TransactionID = db . CreateTransaction ( this . ID , To , ( Int64 ) Amount );
            }
            return TransactionID;
        }
    }
}
