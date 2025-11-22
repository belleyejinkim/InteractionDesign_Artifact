# Health Warning UI 설정 가이드

## 개요
Artifact health가 30이 되었을 때, a.png 이미지와 "열심히 해보세요" 텍스트를 2초 동안 화면에 표시하는 기능을 설정하는 방법입니다.

## 📋 사전 준비

### 1. a.png 이미지 파일 준비
- `a.png` 이미지 파일을 준비합니다
- 이 파일은 나중에 Unity 프로젝트에 추가됩니다

---

## 🔧 Unity 에디터에서 설정하기

### 1단계: Canvas에 UI GameObject 생성

1. **Unity 에디터 열기**
   - `Assets/Scenes/level.unity` 씬을 엽니다

2. **Canvas 찾기**
   - Hierarchy 창에서 **`Canvas`** GameObject를 찾습니다
   - Canvas는 UI 요소들을 담는 부모 컨테이너입니다

3. **Warning Panel GameObject 생성**
   - Hierarchy 창에서 **`Canvas`**를 우클릭합니다
   - `UI > Panel` 선택
   - 생성된 Panel의 이름을 **`HealthWarningPanel`**로 변경합니다

4. **Panel 위치 및 크기 설정**
   - `HealthWarningPanel`을 선택합니다
   - Inspector 창에서 RectTransform 확인:
     - **Anchors**: Center (0.5, 0.5)
     - **Position**: X = 0, Y = 0
     - **Width**: 원하는 크기 (예: 400)
     - **Height**: 원하는 크기 (예: 300)
   - Panel의 Image 컴포넌트는 필요없으므로 **삭제**하거나 **비활성화**합니다
   - 또는 Panel을 사용하지 않고 빈 GameObject를 만들어도 됩니다

---

### 2단계: 이미지 UI 추가

1. **이미지 GameObject 생성**
   - Hierarchy 창에서 **`HealthWarningPanel`**을 우클릭합니다
   - `UI > Image` 선택
   - 생성된 Image의 이름을 **`WarningImage`**로 변경합니다

2. **a.png 이미지 임포트**
   - Project 창에서 `Assets/Sprites/` 폴더를 엽니다
   - `a.png` 파일을 이 폴더로 복사합니다
   - 또는 Unity 에디터에서 `Assets > Sprites` 폴더를 우클릭 → `Import New Asset...` 선택

3. **이미지 Import Settings**
   - Project 창에서 `a.png`를 선택합니다
   - Inspector 창에서:
     - **Texture Type**: `Sprite (2D and UI)` 선택
     - **Apply** 클릭

4. **WarningImage에 이미지 할당**
   - Hierarchy에서 **`WarningImage`**를 선택합니다
   - Inspector의 Image 컴포넌트에서:
     - **Source Image** 필드에 `a.png`를 드래그 앤 드롭합니다
     - 또는 원형 아이콘을 클릭하여 선택합니다

5. **이미지 위치 및 크기 조정**
   - RectTransform을 조정하여 원하는 위치와 크기로 설정합니다
   - 예: Anchor를 Center로 설정하고 Position을 (0, 50) 정도로 설정

---

### 3단계: 텍스트 UI 추가

1. **텍스트 GameObject 생성**
   - Hierarchy 창에서 **`HealthWarningPanel`**을 우클릭합니다
   - `UI > Text - TextMeshPro` 또는 `UI > Text` 선택
   - 생성된 Text의 이름을 **`WarningText`**로 변경합니다

2. **텍스트 내용 설정**
   - Inspector의 Text 컴포넌트에서:
     - **Text**: `열심히 해보세요`
     - **Font Size**: 적절한 크기 (예: 32)
     - **Alignment**: Center (중앙 정렬)
     - **Color**: 원하는 색상

3. **텍스트 위치 조정**
   - RectTransform을 조정하여 이미지 아래에 배치합니다
   - 예: Anchor를 Center로 설정하고 Position을 (0, -50) 정도로 설정

---

### 4단계: HealthWarningUI 스크립트 설정

1. **스크립트가 있는 GameObject 선택**
   - Hierarchy에서 **`HealthWarningPanel`** 또는 **`Canvas`**를 선택합니다
   - (또는 새로운 빈 GameObject를 만들고 이름을 `HealthWarningManager`로 설정)

2. **HealthWarningUI 컴포넌트 추가**
   - Inspector 하단에서 **`Add Component`** 클릭
   - `Health Warning UI` 검색 후 선택

3. **필드 설정**
   - Inspector의 HealthWarningUI 컴포넌트에서:
     - **Artifact**: Hierarchy에서 **`Artifact`** GameObject를 찾아 드래그 앤 드롭
       - 또는 `Manager` GameObject 하위에 있을 수 있습니다
       - Artifact 컴포넌트가 있는 GameObject를 찾아야 합니다
     - **Warning Image**: `WarningImage` GameObject를 드래그 앤 드롭
     - **Warning Text**: `WarningText` GameObject를 드래그 앤 드롭
     - **Warning Health Threshold**: `30` (기본값)
     - **Display Duration**: `2` (2초)

---

### 5단계: 초기 상태 설정 (중요!)

1. **UI 요소들을 기본적으로 비활성화**
   - Hierarchy에서 **`WarningImage`** GameObject를 선택
   - Inspector 상단의 체크박스를 해제하여 비활성화
   - Hierarchy에서 **`WarningText`** GameObject를 선택
   - Inspector 상단의 체크박스를 해제하여 비활성화
   - 또는 **`HealthWarningPanel`** 전체를 비활성화할 수도 있습니다

2. **확인**
   - UI 요소들이 비활성화되어 있어야 합니다
   - 스크립트가 health가 30이 되면 자동으로 활성화합니다

---

## ✅ 최종 체크리스트

- [ ] Canvas에 HealthWarningPanel GameObject 생성됨
- [ ] WarningImage GameObject 생성되고 a.png 이미지 할당됨
- [ ] WarningText GameObject 생성되고 "열심히 해보세요" 텍스트 설정됨
- [ ] HealthWarningUI 스크립트가 GameObject에 추가됨
- [ ] Artifact 필드에 Artifact GameObject 할당됨
- [ ] Warning Image 필드에 WarningImage 할당됨
- [ ] Warning Text 필드에 WarningText 할당됨
- [ ] Warning Health Threshold = 30 설정됨
- [ ] Display Duration = 2 설정됨
- [ ] WarningImage와 WarningText가 기본적으로 비활성화됨

---

## 🎮 테스트 방법

1. **게임 실행**
   - Play 버튼을 눌러 게임을 실행합니다

2. **Health 감소 확인**
   - Artifact health가 30으로 떨어질 때까지 기다립니다
   - 또는 테스트를 위해 Artifact의 health를 직접 30으로 설정할 수 있습니다

3. **경고 UI 확인**
   - Health가 30이 되면:
     - a.png 이미지가 화면에 나타나야 합니다
     - "열심히 해보세요" 텍스트가 나타나야 합니다
     - 2초 후 자동으로 사라져야 합니다

---

## 🔍 문제 해결

### UI가 나타나지 않는 경우
- HealthWarningUI 스크립트의 Artifact 필드가 올바르게 할당되었는지 확인
- WarningImage와 WarningText 필드가 올바르게 할당되었는지 확인
- Artifact의 health가 실제로 30 이하로 떨어졌는지 확인

### 이미지가 보이지 않는 경우
- a.png의 Import Settings에서 Texture Type이 Sprite로 설정되었는지 확인
- WarningImage의 Image 컴포넌트에 이미지가 할당되었는지 확인
- WarningImage의 RectTransform 크기가 0이 아닌지 확인

### 텍스트가 보이지 않는 경우
- WarningText의 Text 컴포넌트에 텍스트가 입력되었는지 확인
- Font Size가 너무 작지 않은지 확인
- Text 색상이 배경과 구분되는지 확인

### 경고가 한 번만 나타나는 경우
- 이는 정상 동작입니다. health가 30 이하로 떨어졌을 때 한 번만 표시됩니다
- 다시 표시하려면 health가 30보다 높아졌다가 다시 30 이하로 떨어져야 합니다
- 또는 HealthWarningUI 스크립트의 `ResetWarning()` 메서드를 호출할 수 있습니다

---

## 📝 참고 사항

- **Health Warning Threshold**: 기본값은 30이지만 Inspector에서 변경 가능합니다
- **Display Duration**: 기본값은 2초이지만 Inspector에서 변경 가능합니다
- **한 번만 표시**: 경고는 health가 30 이하로 떨어졌을 때 한 번만 표시됩니다
- **다시 표시하려면**: health가 30보다 높아졌다가 다시 30 이하로 떨어지면 다시 표시됩니다

---

## 🎨 추가 커스터마이징

### 위치 조정
- WarningImage와 WarningText의 RectTransform을 조정하여 화면 어느 위치에든 배치할 수 있습니다
- Anchor와 Position 값을 변경하여 원하는 위치에 배치하세요

### 스타일 조정
- 텍스트 색상, 크기, 폰트를 변경할 수 있습니다
- 이미지 크기와 색상을 조정할 수 있습니다
- Fade in/out 효과를 추가하려면 CanvasGroup 컴포넌트를 사용할 수 있습니다

---

## 📂 파일 구조

```
Assets/
  ├── Scripts/
  │   └── UI/
  │       └── HealthWarningUI.cs (생성됨)
  ├── Sprites/
  │   └── a.png (추가 필요)
  └── Scenes/
      └── level.unity (Canvas에 UI 추가 필요)
```

이제 Unity 에디터에서 위 단계를 따라 설정하면 health가 30이 될 때 경고가 표시됩니다!
