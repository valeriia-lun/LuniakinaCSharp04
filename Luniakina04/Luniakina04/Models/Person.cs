using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Luniakina04.Tools.Exceptions;

namespace Luniakina04.Models
{
    [Serializable]
    internal class Person
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private int _age = -1;
        private string _sunSign;
        private string _chineseSign;
        private string _birthdayString;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday
        {
            get { return _birthDate; }
            set
            {
                _birthDate = Convert.ToDateTime(value);
                _birthdayString = value.ToShortDateString();
                _age = CalculateAge(_birthDate);
                _sunSign = SunSignFunc(_birthDate);
                _chineseSign = ChineseSignFunc(_birthDate);

                OnPropertyChanged();
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayString");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
            }
        }

        #endregion

        #region Constructors

        private Person(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public Person(string name, string surname, string email, DateTime birthDate) :
            this(name, surname)
        {
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string name, string surname, string email) :
            this(name, surname)
        {
            _email = email;
        }

        public Person(string name, string surname, DateTime birthDate) :
            this(name, surname)
        {
            _birthDate = birthDate;
        }

        #endregion

        #region ReadOnlyProps

        private int Age
        {
            get { return (_age == -1) ? (_age = CalculateAge(_birthDate)) : _age; }
        }

        public bool IsAdult
        {
            get { return (_age != -1) ? 18 <= _age : 18 <= (_age = CalculateAge(_birthDate)); }
        }

        public string BirthdayString
        {
            get { return _birthdayString ?? (_birthDate.ToString("dd MMMM yyyy")); }
        }

        public string SunSign
        {
            get { return _sunSign ?? (_sunSign = SunSignFunc(_birthDate)); }
        }

        public string ChineseSign
        {
            get { return _chineseSign ?? (_chineseSign = ChineseSignFunc(_birthDate)); }
        }

        public bool IsBirthday
        {
            get { return (_birthDate.Day == DateTime.Today.Day) && (_birthDate.Month == DateTime.Today.Month); }
        }

        #endregion



        public void Validate()
        {
            if (Age < 0 || DateTime.Today < Birthday)
            {
                throw new PersonDontExistException();
            }

            if (Age > 135)
            {
                throw new PersonTooOldException();
            }

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(_email))
            {
                throw new InvalidEmailException(_email);
            }
            if (!Regex.IsMatch(Name, @"^[a-zA-Z]+$"))
            {
                throw new InvalidNameException(_name);
            }

            if (!Regex.IsMatch(Surname, @"^[a-zA-Z]+$"))
            {
                throw new InvalidSurnameException(_surname);
            }
        }

        private int CalculateAge(DateTime BirthDate)
        {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now.Month < BirthDate.Month ||
                (DateTime.Now.Month == BirthDate.Month &&
                DateTime.Now.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            //  if (DateTime.Today < BirthDate.Date) throw new BirthdayInTheFutureExc();
            //  if (YearsPassed > 135) throw new TooOldExc();

            return YearsPassed;

            //return (DateTime.Today - Convert.ToDateTime(_birthDate)).Days / 365;
        }

        private string SunSignFunc(DateTime BirthDate)
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;

            if (month == 12 && day >= 22 ||
                month == 1 && day <= 22)
            {
                return ZodiacSignEnumeration.Capricorn.ToString();
            }

            if (month == 1 && day >= 21 ||
                month == 2 && day <= 18)
            {
                return ZodiacSignEnumeration.Aquarius.ToString();
            }

            if (month == 2 && day >= 19 ||
                month == 3 && day <= 20)
            {
                return ZodiacSignEnumeration.Pisces.ToString();
            }

            if (month == 3 && day >= 21 ||
                month == 4 && day <= 20)
            {
                return ZodiacSignEnumeration.Aries.ToString();
            }

            if (month == 4 && day >= 21 ||
                month == 5 && day <= 20)
            {
                return ZodiacSignEnumeration.Taurus.ToString();
            }

            if (month == 5 && day >= 21 ||
                month == 6 && day <= 21)
            {
                return ZodiacSignEnumeration.Gemini.ToString();
            }

            if (month == 6 && day >= 22 ||
                month == 7 && day <= 22)
            {
                return ZodiacSignEnumeration.Cancer.ToString();
            }

            if (month == 7 && day >= 23 ||
                month == 8 && day <= 23)
            {
                return ZodiacSignEnumeration.Leo.ToString();
            }

            if (month == 8 && day >= 24 ||
                month == 9 && day <= 23)
            {
                return ZodiacSignEnumeration.Virgo.ToString();
            }

            if (month == 9 && day >= 24 ||
                month == 10 && day <= 23)
            {
                return ZodiacSignEnumeration.Libra.ToString();
            }

            if (month == 10 && day >= 24 ||
                month == 11 && day <= 22)
            {
                return ZodiacSignEnumeration.Scorpio.ToString();
            }

            if (month == 11 && day >= 23 ||
                month == 12 && day <= 21)
            {
                return ZodiacSignEnumeration.Sagittarius.ToString();
            }

            return "Error";
        }

        private string ChineseSignFunc(DateTime BirthDate)
        {


            switch (BirthDate.Year % 12)
            {
                case 0:
                    return ChineseSignEnumeration.Monkey.ToString();


                case 1:
                    return ChineseSignEnumeration.Rooster.ToString();


                case 2:
                    return ChineseSignEnumeration.Dog.ToString();


                case 3:
                    return ChineseSignEnumeration.Pig.ToString();


                case 4:
                    return ChineseSignEnumeration.Rat.ToString();


                case 5:
                    return ChineseSignEnumeration.Ox.ToString();


                case 6:
                    return ChineseSignEnumeration.Tiger.ToString();


                case 7:
                    return ChineseSignEnumeration.Rabbit.ToString();


                case 8:
                    return ChineseSignEnumeration.Dragon.ToString();


                case 9:
                    return ChineseSignEnumeration.Snake.ToString();


                case 10:
                    return ChineseSignEnumeration.Horse.ToString();


                case 11:
                    return ChineseSignEnumeration.Goat.ToString();


            }
            return "Error";
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

