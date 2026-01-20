using Cysharp.Threading.Tasks;
using GameConfig;
using UnityEngine;

namespace GameLogic
{
    public class EntityModule 
    {
        private TbAssetsPathData TbItem => ConfigSystem.Instance.Tables.TbAssetsPathData;
        
        public async UniTask<GameObject> CreateEntity(int configId)
        {
            // PoolManager.Instance.

            var assetPathData = TbItem.Get(configId);
            
            var obj = await  PoolManager.Instance.GetGameObject(assetPathData.ResourcesName);
            return obj;    
        }
    }
}