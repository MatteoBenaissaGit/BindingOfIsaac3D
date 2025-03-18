using DG.Tweening;
using DungeonAndRoom;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIMiniMap : MonoBehaviour
    {
        [SerializeField] private GameObject _miniMapRoom;
        [SerializeField] private Transform _miniMapRoomsParent;
        [Space] 
        [SerializeField] private float _heightOffset;
        [SerializeField] private float _widthOffset;

        private GameObject[,] _miniRooms;
        private GameObject[,] _miniRoomsOutlines;
        
        public void Initialize(Dungeon dungeon)
        {
            Vector2Int size = dungeon.Size;
            _miniRooms = new GameObject[size.x, size.y];
            _miniRoomsOutlines = new GameObject[size.x, size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    _miniRoomsOutlines[x, y] = Instantiate(_miniMapRoom, _miniMapRoomsParent);
                    _miniRoomsOutlines[x, y].GetComponent<Image>().color = Color.black;
                    _miniRoomsOutlines[x, y].transform.localScale *= 1.5f;
                    _miniRoomsOutlines[x, y].transform.SetAsFirstSibling();
                    _miniRoomsOutlines[x, y].transform.localPosition = new Vector3(x * _widthOffset, y * _heightOffset, 0);
                    
                    _miniRooms[x, y] = Instantiate(_miniMapRoom, _miniMapRoomsParent);
                    _miniRooms[x, y].transform.localPosition = new Vector3(x * _widthOffset, y * _heightOffset, 0);
                }    
            }
        }

        public void SetCurrentRoom(Vector2Int coordinates)
        {
            GameObject room = _miniRooms[coordinates.x, coordinates.y];
            
            for (int x = 0; x < _miniRooms.GetLength(0); x++)
            {
                for (int y = 0; y < _miniRooms.GetLength(1); y++)
                {
                    _miniRooms[x, y].GetComponent<Image>().color = Color.white;
                    _miniRooms[x, y].transform.DOComplete();
                    _miniRooms[x, y].transform.DOLocalMove(new Vector3((x - coordinates.x) * _widthOffset, (y - coordinates.y) * _heightOffset, 0), 0.2f);
                    _miniRoomsOutlines[x, y].transform.DOComplete();
                    _miniRoomsOutlines[x, y].transform.DOLocalMove(new Vector3((x - coordinates.x) * _widthOffset, (y - coordinates.y) * _heightOffset, 0), 0.2f);
                }    
            }
            
            room.GetComponent<Image>().color = new Color(1f, 0.82f, 0f);
        }
    }
}