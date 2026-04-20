using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreApp.Mvvm.Model
{
    public class Citizen : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        private string? _firstname;
        public string? FirstName { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }

        private string? _lastname;
        public string? LastName { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }

        private byte[]? _photo;
        [AllowNull]
        public byte[]? Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        private DateTime _dateofbirth;
        public DateTime DateOfBirth
        {
            get => _dateofbirth; 
            set { _dateofbirth = value; OnPropertyChanged(nameof(DateOfBirth)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
