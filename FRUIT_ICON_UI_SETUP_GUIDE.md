# 열매 아이콘 UI 설정 가이드

## 개요
플레이어가 열매를 수확하면 우측 상단에 열매 이미지가 표시되고, Artifact에 열매를 넣으면 사라지는 기능을 설정하는 방법입니다.

---

## 🔧 Unity 에디터에서 설정하기

### 1단계: Canvas에 열매 아이콘 UI GameObject 생성

1. **Unity 에디터 열기**
   - `Assets/Scenes/level.unity` 씬을 엽니다

2. **Canvas 찾기**
   - Hierarchy 창에서 **`Canvas`** GameObject를 찾습니다

3. **Fruit Icon GameObject 생성**
   - Hierarchy 창에서 **`Canvas`**를 우클릭합니다
   - `UI > Image` 선택
   - 생성된 Image의 이름을 **`FruitIcon`**로 변경합니다

4. **위치 설정 (우측 상단)**
   - **`FruitIcon`**을 선택합니다
   - Inspector 창에서 RectTransform 설정:
     - **Anchors**: Top-Right 선택 (상단 우측 앵커)
       - Anchor Min: (1, 1)
       - Anchor Max: (1, 1)
     - **Pivot**: (0.5, 0.5) - 중심 기준
     - **Position**: X = -100, Y = -100 (우측 상단에서 약간 안쪽)
       - 또는 원하는 위치로 조정
     - **Width**: 적절한 크기 (예: 80)
     - **Height**: 적절한 크기 (예: 80)

5. **Image 컴포넌트 설정**
   - Inspector의 Image 컴포넌트에서:
     - **Color**: 원하는 색상 (흰색으로 두면 이미지 원본 색상 사용)
     - **Raycast Target**: 체크 해제 (클릭 가능하게 하지 않으려면)

---

### 2단계: 열매 이미지 준비 및 할당

**중요**: 열매 종류가 여러 개 있으므로 각 종류별로 다른 이미지를 할당해야 합니다!

1. **열매 이미지 파일 확인**
   - Project 창에서 `Assets/Sprites/` 폴더를 엽니다
   - 열매 이미지 파일 확인:
     - `fruit.png` (Art Pass 1)
     - `fruit0P2.png`, `fruit1P2.png`, `fruit2P2.png` (Art Pass 2)
   - 부시 타입별 열매 이미지를 확인합니다:
     - **Green 부시**: `fruit0P2.png` 또는 해당 스프라이트
     - **Cyan 부시**: `fruit1P2.png` 또는 해당 스프라이트  
     - **Yellow 부시**: `fruit2P2.png` 또는 해당 스프라이트

2. **이미지 Import Settings 확인**
   - 각 열매 이미지를 선택합니다
   - Inspector 창에서:
     - **Texture Type**: `Sprite (2D and UI)` 확인
     - 아니면 `Sprite (2D and UI)`로 변경 후 **Apply** 클릭

3. **FruitIcon의 Image 컴포넌트 설정**
   - Hierarchy에서 **`FruitIcon`**을 선택합니다
   - Inspector의 Image 컴포넌트는 기본적으로 빈 상태로 둡니다
   - 스크립트가 자동으로 열매 종류에 맞는 이미지를 설정합니다

4. **이미지 크기 및 위치 미세 조정**
   - RectTransform을 조정하여 원하는 크기와 위치로 설정합니다
   - 예: 화면 크기에 맞게 Width/Height를 조정

---

### 3단계: FruitIconUI 스크립트 설정

1. **스크립트가 있는 GameObject 선택**
   - Hierarchy에서 **`FruitIcon`**을 선택합니다
   - 또는 Canvas에 새 빈 GameObject를 만들어 이름을 `FruitIconManager`로 설정할 수도 있습니다

2. **FruitIconUI 컴포넌트 추가**
   - Inspector 하단에서 **`Add Component`** 클릭
   - `Fruit Icon UI` 검색 후 선택

3. **필드 설정**
   - Inspector의 FruitIconUI 컴포넌트에서:
     - **Backpack**: Hierarchy에서 **`Player`** GameObject를 찾아 선택
       - Player GameObject는 PlayerBackpack 컴포넌트를 가지고 있습니다
       - 또는 Hierarchy 검색창에 `Player`를 입력하여 찾습니다
       - Player GameObject를 드래그 앤 드롭합니다
     - **Fruit Image**: `FruitIcon` GameObject를 드래그 앤 드롭
     - **Fruit Sprites** (배열): 각 열매 종류별 이미지를 할당합니다
       - 배열 크기: 3개 (Green, Cyan, Yellow 순서)
       - **Element 0**: Green 부시 열매 이미지 (fruit0P2.png 또는 해당 스프라이트)
       - **Element 1**: Cyan 부시 열매 이미지 (fruit1P2.png 또는 해당 스프라이트)
       - **Element 2**: Yellow 부시 열매 이미지 (fruit2P2.png 또는 해당 스프라이트)
       - 각 요소에 Project 창에서 해당 열매 이미지 스프라이트를 드래그 앤 드롭
       - 부시 prefab의 BushVisual 컴포넌트에 있는 fruitSprites 배열과 동일한 순서여야 합니다

---

### 4단계: 초기 상태 설정 (중요!)

1. **FruitIcon을 기본적으로 비활성화**
   - Hierarchy에서 **`FruitIcon`** GameObject를 선택합니다
   - Inspector 상단의 체크박스를 해제하여 비활성화합니다
   - 스크립트가 열매가 있을 때 자동으로 활성화합니다

2. **확인**
   - FruitIcon이 비활성화되어 있어야 합니다
   - 게임 시작 시 열매 아이콘이 보이지 않아야 합니다

---

## ✅ 최종 체크리스트

- [ ] Canvas에 FruitIcon GameObject 생성됨
- [ ] FruitIcon이 우측 상단에 위치함
- [ ] FruitIconUI 스크립트가 GameObject에 추가됨
- [ ] Backpack 필드에 Player GameObject 할당됨
- [ ] Fruit Image 필드에 FruitIcon 할당됨
- [ ] Fruit Sprites 배열에 3개의 열매 이미지가 할당됨 (Green, Cyan, Yellow 순서)
  - [ ] Element 0: Green 부시 열매 이미지
  - [ ] Element 1: Cyan 부시 열매 이미지
  - [ ] Element 2: Yellow 부시 열매 이미지
- [ ] FruitIcon이 기본적으로 비활성화됨

---

## 🎮 테스트 방법

1. **게임 실행**
   - Play 버튼을 눌러 게임을 실행합니다

2. **열매 수확 확인**
   - 플레이어가 부시 근처에서 E 또는 Space 키를 눌러 열매를 수확합니다
   - 우측 상단에 열매 이미지가 나타나야 합니다

3. **열매 전달 확인**
   - 플레이어가 Artifact에 접촉합니다 (열매를 전달)
   - 우측 상단의 열매 이미지가 사라져야 합니다

4. **반복 확인**
   - 다시 열매를 수확하면 이미지가 다시 나타나고
   - 다시 Artifact에 전달하면 이미지가 사라집니다

---

## 🔍 문제 해결

### 아이콘이 나타나지 않는 경우
- FruitIconUI 스크립트의 Backpack 필드가 올바르게 할당되었는지 확인
- Fruit Image 필드가 올바르게 할당되었는지 확인
- Player GameObject가 PlayerBackpack 컴포넌트를 가지고 있는지 확인
- 열매를 실제로 수확했는지 확인 (backpack.current > 0)

### 아이콘이 사라지지 않는 경우
- Artifact에 접촉했는지 확인
- PlayerBackpack의 TakeFruits() 메서드가 호출되는지 확인
- 스크립트의 Update() 메서드가 정상적으로 실행되는지 확인

### 이미지가 보이지 않는 경우
- FruitIcon의 Image 컴포넌트에 이미지가 할당되었는지 확인
- FruitIcon의 RectTransform 크기가 0이 아닌지 확인
- FruitIcon의 Color가 투명하지 않은지 확인
- FruitIcon이 Canvas 안에 있는지 확인

### 위치가 잘못된 경우
- RectTransform의 Anchors를 Top-Right로 설정했는지 확인
- Position 값을 조정하여 원하는 위치로 이동
- Screen Space - Overlay 모드에서는 화면 좌표계를 사용합니다

---

## 📝 참고 사항

### 동작 원리
- 스크립트는 매 프레임마다 `backpack.current`와 `backpack.currentFruitType`을 확인합니다
- `backpack.current > 0`이고 `backpack.currentFruitType`이 있으면 FruitIcon을 활성화합니다
- 열매 종류에 따라 Fruit Sprites 배열에서 해당하는 이미지를 선택하여 표시합니다
- `backpack.current == 0`이면 FruitIcon을 비활성화합니다
- Artifact에 열매를 전달하면 `backpack.TakeFruits()`가 호출되어 `current`가 0이 되고 `currentFruitType`이 null이 됩니다
- 플레이어가 열매를 수확할 때, 수확한 부시의 열매 타입이 backpack에 저장됩니다

### 열매 이미지 선택
- 각 부시 타입별로 다른 열매 이미지를 사용합니다
- BushVisual의 fruitSprites 배열과 동일한 순서로 Fruit Sprites 배열을 설정해야 합니다:
  1. Green 부시 열매 (fruit0P2.png 또는 해당 스프라이트)
  2. Cyan 부시 열매 (fruit1P2.png 또는 해당 스프라이트)
  3. Yellow 부시 열매 (fruit2P2.png 또는 해당 스프라이트)
- 부시 prefab의 BushVisual 컴포넌트를 확인하여 정확한 스프라이트를 찾을 수 있습니다

### 추가 커스터마이징
- 크기 조정: RectTransform의 Width/Height를 변경
- 위치 조정: Position X/Y 값을 변경
- 애니메이션: Image 컴포넌트에 CanvasGroup을 추가하여 페이드 효과 적용 가능
- 여러 열매: 열매 종류에 따라 다른 이미지를 표시하려면 스크립트 수정 필요

---

## 📂 파일 구조

```
Assets/
  ├── Scripts/
  │   └── UI/
  │       └── FruitIconUI.cs (생성됨)
  ├── Sprites/
  │   └── [열매 이미지 파일들]
  └── Scenes/
      └── level.unity (Canvas에 UI 추가 필요)
```

---

## 🎨 UI 위치 참고

```
┌─────────────────────────────────┐
│                            🍎    │ ← FruitIcon (우측 상단)
│                                 │
│                                 │
│                                 │
│                                 │
│                                 │
└─────────────────────────────────┘
```

이제 Unity 에디터에서 위 단계를 따라 설정하면 열매를 수확했을 때 우측 상단에 열매 이미지가 표시되고, Artifact에 전달하면 사라집니다!
