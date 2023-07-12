using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void onHit(int b_currentLife);
    public delegate void ondestroyer(Idamageable objectDestroyer);
     
    public interface Idamageable
    {
        event onHit onHit;

        event ondestroyer ondestroyer;
       
        bool o_isdestroyed { get; set; }

        

        void DamageLife(int damage);

        void destroy();
    }
}
