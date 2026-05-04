using UnityEngine;
using UnityEngine.Events;

namespace GameVanilla.Game.Common
{
	/// <summary>
	/// The base class used for the tile entities in the game.
	/// </summary>
	public class TileEntity : MonoBehaviour
	{
		public UnityEvent onSpawn;
		public UnityEvent onExplode;

		/// <summary>
		/// Unity's OnEnable method.
		/// </summary>
		public virtual void OnEnable()
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			if (spriteRenderer != null)
			{
				var newColor = spriteRenderer.color;
				newColor.a = 1.0f;
				spriteRenderer.color = newColor;
			}
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			transform.localRotation = Quaternion.identity;
		}

		/// <summary>
		/// Unity's OnDisable method.
		/// </summary>
		public virtual void OnDisable()
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			if (spriteRenderer != null)
			{
				var newColor = spriteRenderer.color;
				newColor.a = 1.0f;
				spriteRenderer.color = newColor;
			}
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			transform.localRotation = Quaternion.identity;
		}

		/// <summary>
		/// Called when this tile entity is spawned on a level.
		/// </summary>
		public virtual void Spawn()
		{
			onSpawn.Invoke();
		}

		/// <summary>
		/// Called when this tile entity explodes.
		/// </summary>
		public virtual void Explode()
		{
			onExplode.Invoke();
		}
	}
}
