using EDO.UI.WebUI.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models
{
    [Serializable]
    public class RegistrationViewModel
    {
        public int CurrentStepIndex { get; set; }
        public IList<IRegistrationStepVM> Steps { get; set; }
        public IList<string> StepTitles { get; set; }

        public RegistrationViewModel()
        {
            CurrentStepIndex = 0;
            Steps = new List<IRegistrationStepVM>();
            StepTitles = new List<string>();

            TruncateToFirstStep();
        }

        public IRegistrationStepVM GetNextStep()
        {
            if (CurrentStepIndex > 0 && !IsTypeOk(CurrentStepIndex))
            {
                return TruncateToFirstStep();
            }

            var nextStep = GetNextStepByAccountType(CurrentStepIndex + 1);

            if (nextStep == null)
            {
                return Steps.ElementAt(CurrentStepIndex);
            }

            ++CurrentStepIndex;

            return nextStep;
        }

        public IRegistrationStepVM GetPreviousStep()
        {
            if (CurrentStepIndex <= 1)
            {
                CurrentStepIndex = 0;
                return GetFirstStep();
            }

            var previous = Steps.ElementAtOrDefault(CurrentStepIndex - 1);
            if (previous == null)
            {
                return TruncateToFirstStep();
            }

            --CurrentStepIndex;
            return previous;
        }

        protected IRegistrationStepVM GetFirstStep()
        {
            return Steps.ElementAtOrDefault(0);
        }

        /**
         * Сбросим весь визард на первый шаг
         * Если не было первого шага инициализируем новые
         * Если был - используем существующий
         */
        private IRegistrationStepVM TruncateToFirstStep()
        {
            CurrentStepIndex = 0;

            var firstStep = GetFirstStep();

            Steps.Clear();

            Steps.Add(firstStep ?? new ChooseAccountType());

            StepTitles.Clear();
            StepTitles.Add("Выбор типа аккаунта");

            return Steps.ElementAt(0);
        }

        private bool IsTypeOk(int stepIndex)
        {
            var currentStep = Steps.ElementAtOrDefault(stepIndex);
            var firstStep = GetFirstStep() as ChooseAccountType;

            if (firstStep == null) return false;

            switch (firstStep.AccountTypeCode.ToLower())
            {
                case "individual": return currentStep is IIndividualRegStep;
                case "business": return currentStep is IBusinessRegStep;
                case "private": return currentStep is IPrivateRegStep;
            }

            return false;
        }

        protected IRegistrationStepVM GetNextStepByAccountType(int stepIndex)
        {
            // Проверим что след шаг наличиствует и если он соответствует типу - возвращаем его
            var step = Steps.ElementAtOrDefault(stepIndex);
            
            if (IsTypeOk(stepIndex))
            {
                if (step != null)
                {
                    return step;
                }
            }
            else
            {
                TruncateToFirstStep();
            }
            
            var stepTitle = "";

            var firstStep = GetFirstStep() as ChooseAccountType;

            if (firstStep != null)
            {
                switch (firstStep.AccountTypeCode.ToLower())
                {
                    case "individual":
                        {
                            Steps.Add(new IndividualBase());
                            StepTitles.Add("Основные данные");
                            Steps.Add(new IndividualInfo());
                            StepTitles.Add("Реквизиты и адреса");
                            Steps.Add(new IndividualIdentity());
                            StepTitles.Add("Идентификационные данные");
                            Steps.Add(new IndividualFiles());
                            StepTitles.Add("Файлы");
                        }
                        break;
                    case "business":
                        {
                            Steps.Add(new BusinessBase());
                            StepTitles.Add("Основные данные");
                            Steps.Add(new BusinessInfo());
                            StepTitles.Add("Реквизиты и адреса");
                            Steps.Add(new BusinessContacts());
                            StepTitles.Add("Контакты");
                            Steps.Add(new BusinessFiles());
                            StepTitles.Add("Файлы");
                        }
                        break;
                    case "private":
                        {
                            Steps.Add(new PrivateBase());
                            StepTitles.Add("Основные данные");
                            Steps.Add(new PrivateInfo());
                            StepTitles.Add("Реквизиты и адреса");
                            Steps.Add(new PrivateIdentity());
                            StepTitles.Add("Идентификационные данные");
                            Steps.Add(new PrivateFiles());
                            StepTitles.Add("Файлы");
                        }
                        break;
                }
            }

            return Steps.ElementAtOrDefault(stepIndex);
        }
    }
}