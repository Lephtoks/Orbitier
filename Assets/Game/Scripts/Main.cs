using System;
using System.ComponentModel;
using System.IO;
using Game.Scripts.Blocks;
using Game.Scripts.Blocks.Links;
using Game.Scripts.Data;
using Game.Scripts.Entity;
using Game.Scripts.Entity.Player;
using Game.Scripts.Registry;
using Game.Scripts.Render;
using Game.Scripts.Tiling;
using Game.Scripts.World;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts
{
    public class Main : MonoBehaviour
    {
        private GameTileMap _map;
        private WorldMap _world;
        private Camera _mainCamera;
        private DrawableObject _hoveredDrawable;
        private Tile _hoveredTile;
        private Vector3 _mouseWorldPos;
        private LoadedEntity _spectatingEntity;
        
        private Vector2 _movement;
        
        private LinkPoint _selectedLinkPoint;

        private void Start()
        {
            _mainCamera = Camera.main;
            
            OrbitierAssets.RegisterAssetReader("orbitier", Application.dataPath + "/Resources");
            
            Registration();
            
            
            _map = new GameTileMap();
            _world = new WorldMap(_map);

            _map.GenerateChunk(new Vector2(0, 0));
            _map.GenerateChunk(new Vector2(-1, 0));
            _map.GenerateChunk(new Vector2(0, -1));
            _map.GenerateChunk(new Vector2(-1, -1));

            _map.GenerateChunk(new Vector2(2, 0));

            _map.GenerateChunk(new Vector2(1, 1));

            _map.GenerateChunk(new Vector2(0, 2));
            
            var player = new Player(Vector2.zero);
            _spectatingEntity = player;
            ObjectRenderer.ShowObject(player);
        }
        
        public static readonly MainRegistrar VANILLA = new MainRegistrar("orbitier");

        private void Update()
        {
            _mouseWorldPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _mouseWorldPos.z = 0;

            _hoveredDrawable = null;

            bool clicked = Input.GetMouseButtonDown(0);
            bool released = Input.GetMouseButtonUp(0);
            bool linkPointStopped = false;
            foreach (var drawable in ObjectRenderer.DRAWABLES)
            {
                if (drawable is Tile tile && tile.TileType.GetHoverShape().IsIn(tile.GetPosition(), _mouseWorldPos))
                {
                    _hoveredDrawable = drawable;
                }

                if (drawable is LinkableBlock linkableBlock)
                {
                    foreach (var link in linkableBlock.GetLinkPoints())
                    {
                        
                    }

                }
                if (!linkPointStopped && (clicked || released) && drawable is LinkableBlock block)
                {
                    foreach (var link in block.GetLinkPoints())
                    {
                        if (Vector2.Distance(_mouseWorldPos, link.Point + block.GetPosition()) < 0.5f)
                        {
                            if (clicked) _selectedLinkPoint = link;
                            else
                            {
                                _selectedLinkPoint.LinkWIth(link);
                            };
                            linkPointStopped = true;
                            break;
                        };
                    }
                }
            }

            if (released)
            {
                _selectedLinkPoint = null;
            }
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            _movement = new Vector2(horizontal, vertical);

            if (Input.GetMouseButtonUp(0))
            {
                if (_hoveredDrawable is Tile tile)
                {
                    var pulsarBlock = new PulsarBlock();
                    tile.SetBlock(pulsarBlock);
                    ObjectRenderer.ShowObject(pulsarBlock);
                    
                }
            }
        }

        private void FixedUpdate()
        {
            ScheduleManager.Time = Time.timeAsDouble;
            
            if (_spectatingEntity is IControllable controllable)
            {
                _spectatingEntity.SetPosition(_movement.normalized * controllable.getSpeed() + _spectatingEntity.GetPosition());
            }

            if (_spectatingEntity != null)
            {
                Vector2 position = _spectatingEntity.GetPosition();
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, new Vector3(position.x, position.y, _mainCamera.transform.position.z), 
                    Mathf.Pow(0.9340f, 1/Time.deltaTime));
            }
        }

        private void OnDrawGizmos()
        {
            if (_hoveredDrawable is not Tile tile) return;
            
            Gizmos.color = Color.yellow;

            var ve = tile.TileType.GetHoverShape().GetVertices();
            for (int i = 0; i < ve.Length - 1; ++i)
            {
                var vertex = ve[i] + tile.GetPosition();
                var vertex2 = ve[i + 1] + tile.GetPosition();

                Gizmos.DrawLine(vertex, vertex2);
            }
        }

        private void OnGUI()
        {
            if (_hoveredTile != null)
            {
                GUI.Label(new Rect(10, 10, 200, 20), "Pos: " + _hoveredTile.GetPosition());
            }
        }

        private void Registration()
        {
            GameTiles.Init();
        }
    }

    [Serializable]
    public class TST
    {
        public int i;
    }
    
}

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit{}
}