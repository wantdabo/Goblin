using GoblinFramework.Core;
using GoblinFramework.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinFramework.Gameplay.Common
{
    /// <summary>
    /// IPlayLoop，战斗循环
    /// </summary>
    public interface IPLoop { public void Update(int frame); }

    /// <summary>
    /// Play-Tick-Engine-Comp, 玩法 Tick 驱动组件
    /// </summary>
    public class PTickEngineComp : Comp<PGEngineComp>
    {
        private List<IPLoop> iploops = new List<IPLoop>();

        protected override void OnCreate()
        {
            base.OnCreate();
        }

        protected override void OnDestroy()
        {
            iploops.Clear();
            iploops = null;

            base.OnDestroy();
        }

        public void AddUpdate(IPLoop update) { iploops.Add(update); }
        public void RmvUpdate(IPLoop update) { iploops.Remove(update); }

        public void Update(int frame)
        {
            if (0 > iploops.Count) return;
            for (int i = iploops.Count - 1; i >= 0; i--) iploops[i].Update(frame);
        }
    }
}
