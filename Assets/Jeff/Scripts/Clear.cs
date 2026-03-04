using UnityEngine;

public class Clear : MonoBehaviour
{
    private Texture2D m_Texture;
    private Color[] m_Colors;
    private SpriteRenderer spriteRend;
    private RaycastHit2D hit;

    public int erSize = 20;

    private Vector2Int lastPos;
    private bool isDrawing = false;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        Texture2D originalTex = spriteRend.sprite.texture;

        // 创建可修改纹理
        m_Texture = new Texture2D(originalTex.width, originalTex.height, TextureFormat.ARGB32, false);
        m_Texture.filterMode = FilterMode.Bilinear;
        m_Texture.wrapMode = TextureWrapMode.Clamp;

        m_Colors = originalTex.GetPixels();
        m_Texture.SetPixels(m_Colors);
        m_Texture.Apply();

        // 只创建一次 Sprite
        spriteRend.sprite = Sprite.Create(
            m_Texture,
            spriteRend.sprite.rect,
            new Vector2(0.5f, 0.5f),
            spriteRend.sprite.pixelsPerUnit
        );
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = false; // 新的一笔
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                EraseAtPoint(hit.point);
            }
        }
    }

    void EraseAtPoint(Vector2 worldPoint)
    {
        int w = m_Texture.width;
        int h = m_Texture.height;

        // 正确转换为局部坐标
        Vector2 localPos = transform.InverseTransformPoint(worldPoint);

        float pixelsPerUnit = spriteRend.sprite.pixelsPerUnit;

        localPos.x *= pixelsPerUnit;
        localPos.y *= pixelsPerUnit;

        localPos += new Vector2(w / 2f, h / 2f);

        Vector2Int p = new Vector2Int(
            Mathf.FloorToInt(localPos.x),
            Mathf.FloorToInt(localPos.y)
        );

        if (!isDrawing)
        {
            lastPos = p;
            isDrawing = true;
        }

        Vector2 dir = p - lastPos;
        float sqrMag = dir.sqrMagnitude;

        int startX = Mathf.Clamp(Mathf.Min(p.x, lastPos.x) - erSize, 0, w);
        int startY = Mathf.Clamp(Mathf.Min(p.y, lastPos.y) - erSize, 0, h);
        int endX = Mathf.Clamp(Mathf.Max(p.x, lastPos.x) + erSize, 0, w);
        int endY = Mathf.Clamp(Mathf.Max(p.y, lastPos.y) + erSize, 0, h);

        for (int x = startX; x < endX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                Vector2 pixel = new Vector2(x, y);
                Vector2 closestPoint = p;

                if (sqrMag > 0.01f) // 防止除0
                {
                    float t = Vector2.Dot(pixel - lastPos, dir) / sqrMag;
                    t = Mathf.Clamp01(t);
                    closestPoint = Vector2.Lerp(lastPos, p, t);
                }

                if ((pixel - closestPoint).sqrMagnitude <= erSize * erSize)
                {
                    m_Colors[x + y * w].a = 0; // 只改透明度
                }
            }
        }

        lastPos = p;

        m_Texture.SetPixels(m_Colors);
        m_Texture.Apply();
    }
}
