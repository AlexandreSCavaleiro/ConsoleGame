using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoUC
{
    public abstract class MonoBehaviour
    {
        //attr
        private Thread t;
        private bool rodando = true;

        public void Run()
        {
            Awake();
            Start();

            t = new Thread(
                () =>
                {
                    while (rodando) {
                        Update();
                        LateUpdate();
                        Thread.Sleep(800);
                    }

                    OnDestroy();
                }    
            );

            t.Start();
        }

        public void Stop()
        {
            this.rodando = false;
            t.Join();
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void OnDestroy() { }

    }
}
