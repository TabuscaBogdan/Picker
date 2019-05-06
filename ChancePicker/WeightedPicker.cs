using System;
using System.Collections.Generic;
using System.Text;

namespace ChancePicker
{
    public class WeightedPicker
    {
        public int totalPoints;
        public List<WeightedChoice> weightedChoices;

        public WeightedPicker()
        {
            totalPoints = 0;
            weightedChoices = new List<WeightedChoice>();
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
    }
}
