using UniRx;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Holo5GunGame.Model
{
    public class ModelBese : ScriptableObject
    {
        protected const string PLAYER_DEFAULT_DATA = "Data/Player/PlayerDefault Data.asset";
        protected const string MAIN_GAME_DATA = "Data/Main Game Data.asset";

        private Subject<object> _onCompleteLoad = new Subject<object>();
        protected IObservable<object> OnCompleteLoadData => _onCompleteLoad;

        protected Subject<object> _onReady = new Subject<object>();
        public IObservable<object> OnReady => _onReady;

        protected void LoadDataAsset(string name)
        {
            Addressables.LoadAssetAsync<Data.DataBase>(name).Completed +=
               op => _onCompleteLoad.OnNext(op.Result);
        }

    }

}