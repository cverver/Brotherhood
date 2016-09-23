using System . Collections . Generic;
using System . Linq;
using Microsoft . VisualStudio . TestTools . UnitTesting;

namespace BrotherhoodLibrary . Tests {
    [TestClass ( )]
    public class AccountTests {
        [TestMethod ( )]
        public void MakeTransactionTest ( ) {
            Account a1;
            Account a2;
            using ( BrotherhoodModel db = new BrotherhoodModel ( ) ) {
                List<Account> a = db . Accounts . ToList ( );
                a1 = a [ 0 ];
                a2 = a [ 1 ];
            }
            System . Console . WriteLine ( a1 . MakeTransaction ( a2 . ID , 5 ) . ToString ( ) );
        }
    }
}