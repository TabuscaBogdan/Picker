using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChancePicker
{
    public class WeightedPicker
    {
        public int totalPoints;
        public List<WeightedChoice> weightedChoices;
        private Random dice;

        public WeightedPicker()
        {
            totalPoints = 0;
            weightedChoices = new List<WeightedChoice>();
            dice = new Random();
        }

        public void AddChoice(Choice choice)
        {
            totalPoints += choice.Points;
            var weightedChoice = new WeightedChoice
            {
                Name = choice.Name,
                Points = choice.Points,
            };

            weightedChoices.Add(weightedChoice);
            UpdateWeightedChoiceList();
        }

        public void UpdateChoice(string choiceName, int points)
        {
            var choice = weightedChoices.FirstOrDefault(c => c.Name == choiceName);
            
            choice.Points += points;
            if (choice.Points <= 0)
            {
                points = choice.Points - points;
                weightedChoices.Remove(choice);
            }

            totalPoints += points;
            UpdateWeightedChoiceList();
        }

        public void RemoveChoice(string choiceName)
        {
            var choice = weightedChoices.FirstOrDefault(c => c.Name == choiceName);
            totalPoints -= choice.Points;
            weightedChoices.Remove(choice);
            UpdateWeightedChoiceList();
        }

        private void UpdateWeightedChoiceList()
        {
            foreach (var wChoice in weightedChoices)
            {
                wChoice.Probability = PrecentCalculator.GetPrecentage(wChoice.Points, totalPoints);
            }
            weightedChoices.Sort((x,y) => x.Probability.CompareTo(y.Probability));
            double cumulativeProbability = 0;
            foreach (var wChoice in weightedChoices)
            {
                cumulativeProbability += wChoice.Probability;
                wChoice.CumulativeProbability = cumulativeProbability;
            }
        }

        public string PickWeightedChoice()
        {
            double diceRoll = dice.NextDouble();
            diceRoll *= 100;

            for (int i = 0; i < weightedChoices.Count; i++)
            {
                if (weightedChoices[i].CumulativeProbability >= diceRoll)
                {
                    return weightedChoices[i].Name;
                }
            }

            return "";
        }

        public void ShowStatus()
        {
            foreach (var wChoice in weightedChoices)
            {
                Console.WriteLine($"{wChoice.Name}  Points:{wChoice.Points}   GenerationChance:{wChoice.Probability}%");
            }
        }
    }
}
