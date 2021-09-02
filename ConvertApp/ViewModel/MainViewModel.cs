using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertApp.Model;
using ConvertApp.Repository;

namespace ConvertApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RestRepository repository;

        private Root data;
        public MainViewModel()
        {
            repository = new RestRepository();
            data = repository.GetCurs();
            _valutList = data.Valute.Values.ToArray();
            FirstValut = ValutList[0];
            SecondValut = ValutList[1];
        }
        private Valute[] _valutList;
        public Valute[] ValutList
        {
            get => _valutList;
            set
            {
                if (value == null)
                {
                    return;
                }

                _valutList = value;
                OnPropertyChanged(nameof(ValutList));
                
            }
        }

        private Commander _swap;
        public Commander Swap
        {
            get => _swap ?? (_swap = new Commander(
                obj =>
                {
                    Valute tmp = FirstValut;
                    FirstValut = SecondValut;
                    SecondValut = tmp;
                }));
        }

        private Commander _refresh;
        public Commander Refresh
        {
            get => _refresh ?? (_refresh = new Commander(
                obj =>
                {
                    data = repository.GetCurs();
                    _valutList = data.Valute.Values.ToArray();
                }));
        }

        private Commander _search;
        public Commander Search
        {
            get => _search ?? (_search = new Commander(
                obj =>
                {
                    foreach(Valute val in ValutList)
                    {
                        if(Code== val.CharCode || Code==val.NumCode || Code==val.Name)
                        {
                            num3 = Math.Round(1 * (ValutList[4].Value / val.Value), 2);
                            num4 = Math.Round(1 * (ValutList[10].Value / val.Value), 2);
                        }
                    }
                }));
        }

        private Valute _firstValut;
        public Valute FirstValut
        {
            get => _firstValut;
            set
            {
                if (value == null)
                {
                    return;
                }

                _firstValut = value;
                OnPropertyChanged(nameof(FirstValut));
                num1 = num1;
            }
        }

        private Valute _secondValut;
        public Valute SecondValut
        {
            get => _secondValut;
            set
            {
                if (value == null)
                {
                    return;
                }

                _secondValut = value;
                OnPropertyChanged(nameof(SecondValut));
                num1 = num1;
            }
        }


        private double _num1;
        public double num1
        {
            get => _num1;
            set
            {
                _num1 = value;
                OnPropertyChanged("num2");
            }
        }

        private double _num2;
        public double num2
        {
            get => Math.Round(num1 * (FirstValut.Value / SecondValut.Value), 2);
            set
            {
                _num2 = value;
                OnPropertyChanged("num1");
            }

        }

        private double _num3;
        public double num3
        {
            get => _num3;
            set
            {
                _num3 = value;
                OnPropertyChanged("num3");
            }
        }

        private double _num4;
        public double num4
        {
            get => _num4;
            set
            {
                _num4 = value;
                OnPropertyChanged("num4");
            }
        }

        private string _code;
        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }

        }
    }
}
