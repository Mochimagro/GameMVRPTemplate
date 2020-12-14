using UniRx;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Holo5GunGame.Model
{
    public class ModelBese
    {
        protected const string PLAYER_DEFAULT_DATA = "Data/Player/PlayerDefaultData";
        protected const string MAIN_GAME_DATA = "Data/MainGameData";
        protected const string CHARACTER_SELECT_SETTING = "Data/CharacterSelectSettingData";

        /// <summary>
        /// ロードが完了した(Model用)
        /// </summary>
        protected IObservable<Data.IData> OnCompleteLoadData => _onCompleteLoad;
        private Subject<Data.IData> _onCompleteLoad = new Subject<Data.IData>();

        /// <summary>
        /// Modelの準備が完了した(Presenter用)
        /// </summary>
        public IObservable<object> OnReady => _onReady;
        protected Subject<object> _onReady = new Subject<object>();

        protected void LoadDataAsset<TData>(string name) where TData : Data.IData
        {
            Addressables.LoadAssetAsync<TData>(name).Completed +=
               op => _onCompleteLoad.OnNext(op.Result);
        }

    }

}