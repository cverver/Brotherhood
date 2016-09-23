using System . Data;

namespace BrotherhoodLibrary {
    using System;
    using System . Data . Entity;
    using System . Data . SqlClient;
    public partial class BrotherhoodModel : DbContext {
        public BrotherhoodModel ( )
            : base ( "name=BrotherhoodDatabase" ) {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual Int64 CreateTransaction ( Int64 FromID , Int64 ToID , Int64 CoinAmount ) {
            SqlParameter From = new SqlParameter ( "From" , FromID );
            SqlParameter To = new SqlParameter ( "To" , ToID );
            SqlParameter Amount = new SqlParameter ( "Amount" , CoinAmount );
            SqlParameter ID = new SqlParameter ( "ID" , SqlDbType . BigInt ) { Direction=ParameterDirection . Output };
            Database . ExecuteSqlCommand ( "CreateTransaction @From, @To, @Amount, @ID OUT" , From , To , Amount , ID );
            return ( long ) ID . Value;
        }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
            modelBuilder . Entity<Account> ( )
                . HasMany ( e => e . Transactions )
                . WithRequired ( e => e . Account )
                . WillCascadeOnDelete ( false );
        }
    }
}
