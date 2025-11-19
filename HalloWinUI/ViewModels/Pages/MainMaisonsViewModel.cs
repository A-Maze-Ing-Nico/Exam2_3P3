using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainMaisonsViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;
        private MaisonViewModel? _maisonSelectionnee;

        public MaisonViewModel MaisonSelectionnee
        {
            get => _maisonSelectionnee;
            set
            {
                if (_maisonSelectionnee != value)
                {
                    _maisonSelectionnee = value;
                    // TODO: RaisePropertyChanged ici car binding TwoWay (au cas où, par exemple, on désélectionne dans le code).
                }
            }
        }

        public ObservableCollection<MaisonViewModel> Maisons { get; }

        // TODO: Implémenter la notification de changement de propriété
        public string NouvelleMaison { get; set; }

        public MainMaisonsViewModel(IHalloweenDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Maisons = new ObservableCollection<MaisonViewModel>();
        }

        public void ChargerMaisons()
        {
            Maisons.Clear();
            List<Maison> maisons = _dataProvider.GetMaisons();

            if (maisons != null)
            {
                foreach (Maison maison in maisons)
                {
                    Maisons.Add(new MaisonViewModel(maison));
                }
            }
        }

        public void SupprimerMaison()
        {
            if (MaisonSelectionnee != null)
            {
                Maisons.Remove(MaisonSelectionnee); 
            }
        }

        // TODO: Vider le TextBox après l'ajout: NouvelleMaison = string.Empty;
        //        Tu vas voir que le TextBox ne se vide pas. Il faut notifier le
        //        changement de propriété (voir commentaire plus haut).
        public void AjouterMaison(string maisonTexte)
        {
            // TODO: utiliser string.IsNullOrWhiteSpace() pour aussi éiter d'ajouter des espaces vides.
            if (maisonTexte != "")
            {
                Maisons.Add(new MaisonViewModel(new Maison(maisonTexte)));
            }
        }
    }
}
