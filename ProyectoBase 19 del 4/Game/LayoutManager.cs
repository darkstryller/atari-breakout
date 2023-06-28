using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class renderManager
    {
        private static renderManager instance;
        private static List<IRenderer> renderers = new List<IRenderer>();
        public static renderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new renderManager();

                }

                return instance;
            }
        }

        public List<IRenderer> getObjects()
        {
            List<IRenderer> renders = new List<IRenderer>(renderers);
            return renders;
        }

        public void addObject(IRenderer p_newobject)
        {
            renderers.Add(p_newobject);
        }

    }
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
