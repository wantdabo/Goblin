﻿using GoblinFramework.Client;
using GoblinFramework.Client.Comps;
using GoblinFramework.Client.Comps.GameRes;
using GoblinFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinFramework.Common
{
    internal class GameEngineComp : Comp
    {
        internal ClientTickComp EngineTick = null;
        internal GameResComp GameRes = null;

        protected override void OnCreate()
        {
            base.OnCreate();
            EngineTick = AddComp<ClientTickComp>();
            GameRes = AddComp<YooGameResComp>();
        }

        protected override void OnDestroy()
        {
            EngineTick = null;
            GameRes = null;
            base.OnDestroy();
        }
    }
}
