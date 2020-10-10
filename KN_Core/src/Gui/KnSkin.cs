using UnityEngine;

namespace KN_Core {
  public class KnSkin {
    public enum Type {
      Button,
      Box,
      Slider,
      Scroll
    }

    public class SkinState {
      public Color32 TextColor { get; }
      public Texture2D Texture { get; private set; }

      private readonly Color32 elementColor_;

      public SkinState(Color32 elementColor) {
        TextColor = new Color32(0xff, 0xff, 0xff, 0xff);
        elementColor_ = elementColor;
      }

      public SkinState(Color32 elementColor, Color32 textColor) {
        TextColor = textColor;
        elementColor_ = elementColor;
      }

      public void Load(string texturePath) {
        Texture = Embedded.LoadEmbeddedTexture(texturePath, elementColor_);
      }
    }

    public GUISkin Normal { get; }
    public GUISkin Active { get; }

    private readonly SkinState normal_;
    private readonly SkinState hover_;
    private readonly SkinState active_;

    private readonly string texturePath_;

    private readonly Type type_;
    private readonly TextAnchor alignment_;
    private readonly Font font_;

    public KnSkin(Type type, SkinState normal, SkinState hover, SkinState active, string texturePath, TextAnchor alignment, Font font) {
      Normal = ScriptableObject.CreateInstance<GUISkin>();
      Active = ScriptableObject.CreateInstance<GUISkin>();

      type_ = type;

      normal_ = normal;
      hover_ = hover;
      active_ = active;

      texturePath_ = texturePath;
      alignment_ = alignment;
      font_ = font;

      switch (type_) {
        case Type.Button: {
          MakeButton();
          break;
        }
        case Type.Box: {
          MakeBox();
          break;
        }
        case Type.Slider: {
          MakeSlider();
          break;
        }
        case Type.Scroll: {
          MakeScroll();
          break;
        }
      }
    }

    private void MakeButton() {
      normal_.Load(texturePath_);
      hover_.Load(texturePath_);
      active_.Load(texturePath_);

      Normal.button.normal.textColor = normal_.TextColor;
      Normal.button.normal.background = normal_.Texture;
      Normal.button.hover.textColor = hover_.TextColor;
      Normal.button.hover.background = hover_.Texture;
      Normal.button.active.textColor = active_.TextColor;
      Normal.button.active.background = active_.Texture;
      Normal.button.alignment = alignment_;
      Normal.button.font = font_;

      Active.button.normal.textColor = active_.TextColor;
      Active.button.normal.background = active_.Texture;
      Active.button.hover.textColor = active_.TextColor;
      Active.button.hover.background = active_.Texture;
      Active.button.active.textColor = active_.TextColor;
      Active.button.active.background = active_.Texture;
      Active.button.alignment = alignment_;
      Active.button.font = font_;
    }

    private void MakeBox() {
      const int offset = 5;

      normal_.Load(texturePath_);
      hover_.Load(texturePath_);
      active_.Load(texturePath_);

      Normal.box.normal.textColor = normal_.TextColor;
      Normal.box.normal.background = normal_.Texture;
      Normal.box.hover.textColor = hover_.TextColor;
      Normal.box.hover.background = hover_.Texture;
      Normal.box.active.textColor = active_.TextColor;
      Normal.box.active.background = active_.Texture;
      Normal.box.alignment = alignment_;
      Normal.box.font = font_;
      Normal.box.padding = new RectOffset(offset, offset, 0, 0);

      Active.box.normal.textColor = active_.TextColor;
      Active.box.normal.background = active_.Texture;
      Active.box.hover.textColor = active_.TextColor;
      Active.box.hover.background = active_.Texture;
      Active.box.active.textColor = active_.TextColor;
      Active.box.active.background = active_.Texture;
      Active.box.alignment = alignment_;
      Active.box.font = font_;
      Normal.box.padding = new RectOffset(offset, offset, 0, 0);
    }

    private void MakeSlider() {
      normal_.Load(texturePath_);
      hover_.Load(texturePath_);
      active_.Load(texturePath_);

      Normal.horizontalSlider.normal.background = normal_.Texture;
      Normal.horizontalSlider.hover.background = normal_.Texture;
      Normal.horizontalSlider.active.background = normal_.Texture;
      Normal.horizontalSlider.fixedHeight = Gui.Height;
      Normal.horizontalSliderThumb.normal.background = hover_.Texture;
      Normal.horizontalSliderThumb.hover.background = active_.Texture;
      Normal.horizontalSliderThumb.active.background = active_.Texture;
      Normal.horizontalSliderThumb.fixedWidth = Gui.WidthSlider;
      Normal.horizontalSliderThumb.fixedHeight = Gui.Height;

      Normal.label.normal.textColor = normal_.TextColor;
      Normal.label.alignment = alignment_;
      Normal.label.font = font_;
    }

    private void MakeScroll() {
      normal_.Load(texturePath_);
      hover_.Load(texturePath_);
      active_.Load(texturePath_);

      Normal.scrollView.normal.background = normal_.Texture;

      Normal.verticalScrollbar.normal.background = hover_.Texture;
      Normal.verticalScrollbar.stretchHeight = false;
      Normal.verticalScrollbar.stretchWidth = false;
      Normal.verticalScrollbar.fixedWidth = Gui.ScrollBarWidth;

      Normal.verticalScrollbarThumb.normal.background = active_.Texture;
      Normal.verticalScrollbarThumb.stretchHeight = false;
      Normal.verticalScrollbarThumb.stretchWidth = false;
      Normal.verticalScrollbarThumb.stretchWidth = false;

      Normal.box.normal.textColor = normal_.TextColor;
      Normal.box.alignment = alignment_;
      Normal.box.normal.background = hover_.Texture;
      Normal.box.font = font_;
    }
  }
}