using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Passables.Entities
{
    public class StageEntrance : PassableBase
    {
        public float TopYPoint { get; private set; }

        protected override void Awake()
        {
            base.Awake();
        }

        public float TopPoint => TopYPoint;

        public override void OnHitPassable()
        {
            //Holderı bul sonra eğer geçebilirse havada kalmalarını engelle
        }

    }
}
