using System;
using System.Threading;

namespace DateTimeSample
{
    class Program
    {
        /*
            static 屬性會在第一次呼叫時進行初始化

            TimePicker.static_time 儲存的時間點會
                第一次呼叫的時候 or 初始化 TimePicker 物件

            重新初始化物件時
                私有欄位 this._time 時間會被重置為當下時間
                static_time 時間並不會被影響
         */

        static void Main(string[] args)
        {
            TimePicker _timePicker;

            Console.WriteLine("datetime now : {0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
            Console.WriteLine("static_time : {0:yyyy/MM/dd HH:mm:ss}", TimePicker.static_time);
            Console.WriteLine();

            Wait();

            _timePicker = new TimePicker();
            _timePicker.Print();
            _timePicker.AddMinute();
            _timePicker.Print();

            Wait();

            Console.WriteLine("--------------------------");
            Console.WriteLine("regenerate TimePicker instance");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            _timePicker = new TimePicker();
            _timePicker.Print();
            _timePicker.AddMinute();
            _timePicker.Print();
        }

        static void Wait()
        {
            Thread.Sleep(2000);
        }
    }

    internal class TimePicker
    {
        private DateTime _time;

        public TimePicker()
        {
            this._time = DateTime.Now;
        }

        public void AddMinute(int minute = 1)
        {
            this._time = this._time.AddMinutes(minute);

            _static_time = _static_time.AddMinutes(minute);

            Console.WriteLine("[Add {0} Minutes]", minute);
        }

        public void Print()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("column datetime : {0:yyyy/MM/dd HH:mm:ss}", this._time);
            Console.WriteLine("static datetime : {0:yyyy/MM/dd HH:mm:ss}", _static_time);
            Console.WriteLine("--------------------------");
            Console.WriteLine();
        }

            
        private static DateTime _static_time = DateTime.Now;

        public static DateTime static_time 
        {
            get
            {
                return _static_time;
            }
            set
            {
                _static_time = value;
            }
        }
    }
}
