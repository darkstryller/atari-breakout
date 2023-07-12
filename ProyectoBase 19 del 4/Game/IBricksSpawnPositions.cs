using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IBricksSpawnPositions
    {
        int life { get; }

        brickFactory.BrickSpawnPositions Type { get; }
        bool IsActive { get; set; }
        void Reset(Vector2 position);
        Transform Transform { get; set; }
    }
}
