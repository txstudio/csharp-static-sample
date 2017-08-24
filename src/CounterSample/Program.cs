using System;

namespace csharp_static_sample
{
    class Program
    {
        /*
            此方法呈現屬性設定加入 static 關鍵字的差異
            有加入 static 關鍵字的屬性就算類別重新初始化時，會維持原本狀態
            （需額外進行初始化設定）

            沒有加入 static 關鍵字的屬性（使用私有欄位儲存資料）
            在重新初始化類別時，私有欄位的數值會被重設為初始值
         */
        static void Main(string[] args)
        {
            Counter _counter;

            _counter = new Counter();
            _counter.Print();
            _counter.AddCount();
            _counter.Print();
            _counter.AddCount();
            _counter.Print();

            Console.WriteLine("--------------------------");
            Console.WriteLine("renew Counter");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            /*
                重新建立新 Counter 執行個體
                    初始化後 static 屬性的狀態並沒有被重新設定
                    但沒有 static 屬性的數值已經設定為預設值
            */
            _counter = new Counter();
            _counter.Print();
            _counter.AddCount();
            _counter.Print();
            _counter.AddCount();
            _counter.Print();
        }
    }


    ///<summary>計數器類別</summary>
    internal class Counter
    {
        private int _count = 0;

        ///<summary>初始化計數器類別-重設內部計數器=0</summary>
        public Counter() { }

        ///<summary>進行計數增加方法</summary>
        public void AddCount(int count = 1)
        {
            //進行私有欄位與公開屬性的計數累計
            this._count = this._count + count;

            //進行靜態屬性的計數累計
            static_count = static_count + count;
        }

        ///<summary>列印計數器值</summary>
        public void Print()
        {
            Console.WriteLine("count value");
            Console.WriteLine("--------------------------");
            Console.WriteLine("property count : {0}", this.Count);
            Console.WriteLine("static property count : {0}", static_count);
            Console.WriteLine();
        }

        ///<summary>取得目前類別的計數值</summary>
        public int Count
        {
            get
            {
                return this._count;
            }
        }

        private static int _static_count = 0;

        ///<summary>取得靜態宣告的計數值</summary>
        public static int static_count 
        {
            get
            {
                return _static_count;
            }
            set
            {
                _static_count = value;
            }
        }
    }
}
