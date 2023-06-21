using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LayoutManager
    {
        private static LayoutManager instance;

        private List<Brick> bricks = new List<Brick>();

        public void AddBrick(Brick p_newbrick)
        {
            bricks.Add(p_newbrick);
        }

        public List<Brick> GetBricks()
        {
            List<Brick> blocks = new List<Brick>(bricks);
            return blocks;
        }

        public static LayoutManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LayoutManager();
                    
                }

                return instance;
            }
        }
    }
}
