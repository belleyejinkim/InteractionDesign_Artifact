# Health Congratulations UI 설정 가이드

## 개요
Artifact health가 88에서 90으로 증가하여 90에 도달했을 때, 축하 이미지와 "잘했다" 텍스트를 2초 동안 화면에 표시하는 기능입니다.

**중요**: health가 92에서 90으로 떨어졌을 때는 표시되지 않고, 오직 88에서 90으로 올라갔을 때만 표시됩니다.

## 📋 사전 준비

### 1. 축하 이미지 파일 준비
- "잘했다"를 표현하는 이미지 파일을 준비합니다 (예: congratulation.png, goodjob.png 등)
- 이 파일은 나중에 Unity 프로젝트에 추가됩니다

---

## 🔧 Unity 에디터에서 설정하기

### 1단계: Canvas에 축하 UI GameObject 생성

1. **Unity 에디터 열기**
   - `Assets/Scenes/level.unity` 씬을 엽니다

2. **Canvas 찾기**
   - Hierarchy 창에서 **`Canvas`** GameObject를 찾습니다

3. **Congratulations Panel GameObject 생성**
   - Hierarchy 창에서 **`Canvas`**를 우클릭합니다
   - `UI > Panel` 선택
   - 생성된 Panel의 이름을 **`HealthCongratulationsPanel`**로 변경합니다

4. **Panel 위치 및 크기 설정**
   - `HealthCongratulationsPanel`을 선택합니다
   - Inspector 창에서 RectTransform 설정:
     - **Anchors**: Center (0.5, 0.5)
     - **Position**: X = 0, Y = 0
     - **Width**: 원하는 크기 (예: 400)
     - **Height**: 원하는 크기 (예: 300)
   - Panel의 Image 컴포넌트는 필요없으므로 **삭제**하거나 **비활성화**합니다
   - 또는 Panel을 사용하지 않고 빈 GameObject를 만들어도 됩니다

---

### 2단계: 축하 이미지 UI 추가

1. **이미지 GameObject 생성**
   - Hierarchy 창에서 **`HealthCongratulationsPanel`**을 우클릭합니다
   - `UI > Image` 선택
   - 생성된 Image의 이름을 **`CongratulationsImage`**로 변경합니다

2. **축하 이미지 임포트**
   - Project 창에서 `Assets/Sprites/` 폴더를 엽니다
   - 축하 이미지 파일을 이 폴더로 복사합니다
   - 또는 Unity 에디터에서 `Assets > Sprites` 폴더를 우클릭 → `Import New Asset...` 선택

3. **이미지 Import Settings**
   - Project 창에서 축하 이미지를 선택합니다
   - Inspector 창에서:
     - **Texture Type**: `Sprite (2D and UI)` 선택
     - **Apply** 클릭

4. **CongratulationsImage에 이미지 할당**
   - Hierarchy에서 **`CongratulationsImage`**를 선택합니다
   - Inspector의 Image 컴포넌트에서:
     - **Source Image** 필드에 축하 이미지를 드래그 앤 드롭합니다

5. **이미지 위치 및 크기 조정**
   - RectTransform을 조정하여 원하는 위치와 크기로 설정합니다
   - 예: Anchor를 Center로 설정하고 Position을 (0, 50) 정도로 설정

---

### 3단계: 축하 텍스트 UI 추가

1. **텍스트 GameObject 생성**
   - Hierarchy 창에서 **`HealthCongratulationsPanel`**을 우클릭합니다
   - `UI > Text - TextMeshPro` 또는 `UI > Text` 선택
   - 생성된 Text의 이름을 **`CongratulationsText`**로 변경합니다

2. **텍스트 내용 설정**
   - Inspector의 Text 컴포넌트에서:
     - **Text**: `잘했다` (나중에 스크립트에서 설정되지만, 미리 보려면 입력)
     - **Font Size**: 적절한 크기 (예: 36)
     - **Alignment**: Center (중앙 정렬)
     - **Color**: 축하에 어울리는 색상 (예: 노란색, 초록색)

3. **텍스트 위치 조정**
   - RectTransform을 조정하여 이미지 아래에 배치합니다
   - 예: Anchor를 Center로 설정하고 Position을 (0, -50) 정도로 설정

---

### 4단계: HealthCongratulationsUI 스크립트 설정

1. **스크립트가 있는 GameObject 선택**
   - Hierarchy에서 **`HealthCongratulationsPanel`**을 선택합니다
   - (또는 Canvas를 선택하거나 새로운 빈 GameObject를 만들 수도 있습니다)

2. **HealthCongratulationsUI 컴포넌트 추가**
   - Inspector 하단에서 **`Add Component`** 클릭
   - `Health Congratulations UI` 검색 후 선택

3. **필드 설정**
   - Inspector의 HealthCongratulationsUI 컴포넌트에서:
     - **Artifact**: Hierarchy에서 **`artifact`** GameObject를 찾아 드래그 앤 드롭
     - **Congratulations Image**: `CongratulationsImage` GameObject를 드래그 앤 드롭
     - **Congratulations Text**: `CongratulationsText` GameObject를 드래그 앤 드롭
     - **Congratulations Health Threshold**: `90` (기본값)
     - **Display Duration**: `2` (2초)

---

### 5단계: 초기 상태 설정 (중요!)

1. **UI 요소들을 기본적으로 비활성화**
   - Hierarchy에서 **`CongratulationsImage`** GameObject를 선택
   - Inspector 상단의 체크박스를 해제하여 비활성화
   - Hierarchy에서 **`CongratulationsText`** GameObject를 선택
   - Inspector 상단의 체크박스를 해제하여 비활성화
   - 또는 **`HealthCongratulationsPanel`** 전체를 비활성화할 수도 있습니다

2. **확인**
   - UI 요소들이 비활성화되어 있어야 합니다
   - 스크립트가 health가 88에서 90으로 올라갔을 때 자동으로 활성화합니다

---

## ✅ 최종 체크리스트

- [ ] Canvas에 HealthCongratulationsPanel GameObject 생성됨
- [ ] CongratulationsImage GameObject 생성되고 축하 이미지 할당됨
- [ ] CongratulationsText GameObject 생성되고 "잘했다" 텍스트 설정됨
- [ ] HealthCongratulationsUI 스크립트가 GameObject에 추가됨
- [ ] Artifact 필드에 artifact GameObject 할당됨
- [ ] Congratulations Image 필드에 CongratulationsImage 할당됨
- [ ] Congratulations Text 필드에 CongratulationsText 할당됨
- [ ] Congratulations Health Threshold = 90 설정됨
- [ ] Display Duration = 2 설정됨
- [ ] CongratulationsImage와 CongratulationsText가 기본적으로 비활성화됨

---

## 🎮 테스트 방법

1. **게임 실행**
   - Play 버튼을 눌러 게임을 실행합니다

2. **Health 증가 확인**
   - Artifact health가 88 이하에서 시작
   - 과일을 수집하여 health를 증가시킵니다
   - Health가 88 → 89 → 90으로 올라갔을 때 확인합니다

3. **축하 UI 확인**
   - Health가 88에서 90으로 올라갔을 때:
     - 축하 이미지가 화면에 나타나야 합니다
     - "잘했다" 텍스트가 나타나야 합니다
     - 2초 후 자동으로 사라져야 합니다

4. **다시 테스트**
   - Health가 92에서 90으로 떨어졌을 때는 표시되지 않아야 합니다
   - Health가 다시 88 이하로 떨어졌다가 90으로 올라갔을 때 다시 표시되어야 합니다

---

## 🔍 문제 해결

### UI가 나타나지 않는 경우
- HealthCongratulationsUI 스크립트의 Artifact 필드가 올바르게 할당되었는지 확인
- CongratulationsImage와 CongratulationsText 필드가 올바르게 할당되었는지 확인
- Artifact의 health가 실제로 88에서 90으로 증가했는지 확인 (92에서 90으로 떨어진 건 안 됨)

### 92에서 90으로 떨어졌을 때도 표시되는 경우
- 이는 정상이 아닙니다. 스크립트가 health 증가를 제대로 감지하고 있는지 확인하세요
- Update()에서 previousHealth를 올바르게 추적하고 있는지 확인

### 이미지가 보이지 않는 경우
- 축하 이미지의 Import Settings에서 Texture Type이 Sprite로 설정되었는지 확인
- CongratulationsImage의 Image 컴포넌트에 이미지가 할당되었는지 확인
- CongratulationsImage의 RectTransform 크기가 0이 아닌지 확인

### 텍스트가 보이지 않는 경우
- CongratulationsText의 Text 컴포넌트가 올바르게 설정되었는지 확인
- Font Size가 너무 작지 않은지 확인
- Text 색상이 배경과 구분되는지 확인

---

## 📝 참고 사항

### 동작 원리
- 스크립트는 매 프레임마다 이전 health와 현재 health를 비교합니다
- 이전 health < 90 AND 현재 health >= 90이면 축하 UI를 표시합니다
- 이렇게 하면 health가 증가해서 90에 도달했을 때만 표시됩니다

### 다시 표시하기
- Health가 90보다 낮아졌다가 다시 90으로 올라가면 다시 표시됩니다
- 하지만 같은 게임 세션에서 한 번만 표시하려면, 스크립트의 `congratulationsShown` 플래그를 확인하세요

### HealthWarningUI와 함께 사용
- HealthWarningUI (health 30 경고)와 HealthCongratulationsUI (health 90 축하)는 동시에 사용할 수 있습니다
- 각각 독립적으로 동작합니다

---

## 🎨 추가 커스터마이징

### 위치 조정
- CongratulationsImage와 CongratulationsText의 RectTransform을 조정하여 화면 어느 위치에든 배치할 수 있습니다
- 예: 화면 중앙 상단, 화면 오른쪽 등

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
  │       ├── HealthWarningUI.cs (health 30 경고)
  │       └── HealthCongratulationsUI.cs (health 90 축하 - 새로 생성됨)
  ├── Sprites/
  │   └── [축하 이미지 파일] (추가 필요)
  └── Scenes/
      └── level.unity (Canvas에 UI 추가 필요)
```

이제 Unity 에디터에서 위 단계를 따라 설정하면 health가 88에서 90으로 올라갔을 때 축하 메시지가 표시됩니다!
