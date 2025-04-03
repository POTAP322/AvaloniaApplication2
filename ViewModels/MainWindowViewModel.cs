using AvaloniaApplication2.Models;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly Dog _dog;
        private readonly Panther _panther;
        private readonly Turtle _turtle;
        
        private string _outputText = string.Empty;
        public string OutputText
        {
            get => _outputText;
            set => this.RaiseAndSetIfChanged(ref _outputText, value);
        }

        public MainWindowViewModel()
        {
            _dog = new Dog(10, 50);
            _panther = new Panther(15, 75);
            _turtle = new Turtle(5, 15);

            // Подписка на события
            _dog.SoundGiven += (s, e) => OutputText += "Собака лает: Гав-гав!\n";
            _panther.SoundGiven += (s, e) => OutputText += "Пантера рычит: Рррр!\n";
            _panther.TreeClimbed += (s, e) => OutputText += "Пантера залезла на дерево\n";
            _panther.GetDownFromTree += (s, e) => OutputText += "Пантера слезла с дерева\n";

            // Инициализация команд для собаки
            MoveDogCommand = ReactiveCommand.Create(() => 
            {
                _dog.Move();
                OutputText += $"Собака двигается. Скорость: {_dog.Speed}\n";
            });

            StandDogCommand = ReactiveCommand.Create(() => 
            {
                _dog.Stand();
                OutputText += $"Собака останавливается. Скорость: {_dog.Speed}\n";
            });

            DogSoundCommand = ReactiveCommand.Create(() => _dog.MakeSound());

            // Инициализация команд для пантеры
            MovePantherCommand = ReactiveCommand.Create(() => 
            {
                _panther.Move();
                OutputText += $"Пантера двигается. Скорость: {_panther.Speed}\n";
            });

            StandPantherCommand = ReactiveCommand.Create(() => 
            {
                _panther.Stand();
                OutputText += $"Пантера останавливается. Скорость: {_panther.Speed}\n";
            });

            PantherSoundCommand = ReactiveCommand.Create(() => _panther.MakeSound());
            ClimbTreeCommand = ReactiveCommand.Create(() => _panther.ClimbTree());
            GetDownTreeCommand = ReactiveCommand.Create(() => _panther.GetDown());

            // Инициализация команд для черепахи
            MoveTurtleCommand = ReactiveCommand.Create(() => 
            {
                _turtle.Move();
                OutputText += $"Черепаха двигается. Скорость: {_turtle.Speed}\n";
            });

            StandTurtleCommand = ReactiveCommand.Create(() => 
            {
                _turtle.Stand();
                OutputText += $"Черепаха останавливается. Скорость: {_turtle.Speed}\n";
            });
        }
        
        // Команды для собаки
        public ICommand MoveDogCommand { get; }
        public ICommand StandDogCommand { get; }
        public ICommand DogSoundCommand { get; }
        
        // Команды для пантеры
        public ICommand MovePantherCommand { get; }
        public ICommand StandPantherCommand { get; }
        public ICommand PantherSoundCommand { get; }
        public ICommand ClimbTreeCommand { get; }
        public ICommand GetDownTreeCommand { get; }
        
        // Команды для черепахи
        public ICommand MoveTurtleCommand { get; }
        public ICommand StandTurtleCommand { get; }
    }
}