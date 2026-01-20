using Cysharp.Threading.Tasks;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class EntityModule 
    {
        private TbAssetsPathData TbItem => ConfigSystem.Instance.Tables.TbAssetsPathData;
        
        public async UniTask<GameObject> CreateEntity(int configId)
        {
            var assetPathData = TbItem.Get(configId);
            
            var obj = await  PoolManager.Instance.GetGameObject(assetPathData.ResourcesName);
            
#if UNITY_EDITOR 
            obj.name = $"entity {configId}";
#endif
            
            return obj;    
        }
        
        public void ClearEntity(GameObject entity)
        {
            PoolManager.Instance.ClearGameObject(entity);
        }
    }
}