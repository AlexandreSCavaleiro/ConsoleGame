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

        public bool visible = false;
        public bool input = false;

        public int speed = 100;

        public void Run()
        {
            rodando = true;
            Awake();
            Start();

            t = new Thread(
                () =>
                {
                    while (rodando) {
                        Update();
                        LateUpdate();
                        Thread.Sleep(speed);
                    }

                    
                }    
            );

            t.Start();
        }

        public void Stop()
        {
            
            this.rodando = false;
            OnDestroy();
            t.Join();
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void OnDestroy() { }


        public abstract void Draw();

    }
}
