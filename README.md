# 주요 변경사항 요약 (2025.11.26 by 예진)
- 오디오(명주쌤 한숨소리 / CHOI_sound.wav) 추가 (Warning > Inspector에서 Audio Source Component 추가, Health Warning UI의 Warning Clip에 오디오클립 추가) - 11/26
- 오디오(이상원교수님 목소리 / OH_sound.wav) 추가 (Cheers > Inspector에서 Audio Source Component 추가, Health Cheers UI의 Warning Clip에 오디오클립 추가)  - 11/26

# 주요 변경사항 요약 (2025.11.25 by 예진)
- 배경의 연세맵 변경

# 주요 변경사항 요약 (2025.11.22 by 예진)


1. 배경을 연세 맵으로 변경
2. Wolf와 Wolfeater 제거
3. health가 32->30로 될 때, 최명주 선생님 이미지 팝업
4. health가 88->90로 될 때, 이상원 교수님 이미지 팝업
5. 우측 상단의 'Backpack: n/30' 안보이게 설정
6. 열매를 먹었을 때 health가 2씩 증가하게 수정
7. 먹은 열매 이미지가 우측 상단에 보여지게 수정
8. Artifact Health 글씨를 Earth Health로 변경


# 상세 수정사항


## 1. 배경 변경 (GROUND_IMAGE_REPLACE_GUIDE.md)
기존에는 타일이 여러개 반복되는 형태 (64x64픽셀의 타일이 반복되는 형태)였는데, 하나의 통짜 이미지로 변경하였습니다

- 배경 이미지(map.png)를 Assets/Sprites/ArtPass 2에 추가
- Assets > Scenes > level 을 선택하고 Hierarchy에서 ‘Grid’ 비활성화 (GameObject 체크 박스 해제함) - 기존의 타일 제거
- Assets > Scenes > level 을 선택하고 Hierarchy에서 Yonsei_Map’ 이름으로 GameObject (2D Object > Sprites)생성하고 우측 Inspector에서 Sprite Renderer > Sprite에 map.png 추가



## 2. Wolf와 Wolfeater 제거
Wolf와 Wolfeater가 나타나지 않도록 하였습니다.
- Assets/Scenes/level 파일에서 Manager GameObject의 EnemySpawner 컴포넌트를 비활성화







## 3. health가 32->30로 될 때, 최명주 선생님 이미지 팝업 + 음악재생 (HEALTH_WARNING_SETUP_GUIDE.md)
32->30으로 떨어졌을 때만 팝업이 뜨고, 28->30이 될 때는 뜨지 않게 하였습니다.
- Assets/Scripts/UI/HealthWarningUI.cs 파일 생성
- Assets > Sprites > ArtPass 2 하위에 최명주 선생님 이미지(bad_result.png) 추가
- Assets > Scenes > level 을 선택하고 Hierarchy > Canvas에 빈 GameObject 생성 (이름은 Warning으로 설정함)
- Warning 하위 항목으로 Image (UI > Image) 생성 - 우측 Inspector 패널에서 Source Image에 bad_result.png 추가
- Warning 하위 항목으로 Text (UI > Text) 생성하고 글자 위치, 크기 조정
- Warning > Inspector에서 Health Warning UI 컴포넌트 추가하고, Artifact, Warning Image, Warning Text





### 4. health가 88->90로 될 때, 이상원 교수님 이미지 팝업 (HEALTH_CONGRATULATIONS_SETUP_GUIDE.md)
88->90이 되었을 때 뜨고, 92->90이 될 때는 뜨지 않게 하였습니다

- Assets/Scripts/UI/HealthCongratulationsUI.cs 파일 생성
- Assets > Sprites > ArtPass 2 하위에 이상원 교수님 이미지(good_result.png) 추가
- Assets > Scenes > level 을 선택하고 Hierarchy > Canvas에 빈 GameObject 생성 (이름은 Cheers으로 설정함)
- Cheers 하위 항목으로 Image (UI > Image) 생성 - 우측 Inspector 패널에서 Source Image에 good_result.png 추가
- Cheers 하위 항목으로 Text (UI > Text) 생성하고 글자 위치, 크기 조정
- Cheers > Inspector에서 Health Warning UI 컴포넌트 추가하고, Artifact, Warning Image, Warning Text 설정






## 5. 우측 상단의 'Backpack: n/30' 안보이게 설정
- Assets > Scenes > level에서 Hierarchy > Canvas > BackpackTxt 선택하고 우측 Inspector에서 BackpackTxt 체크박스 해제



## 6. 열매를 먹었을 때 health가 2씩 증가하게 수정
기존에는 열매 종류에 따라서 3개, 10개, 7개씩 증가하는 방식이었는데, 모두 2로 변경하였습니다.
- Assets/Scripts/Bush/BushFruits.cs 코드 수정 (return 2; // Always return 2 fruits regardless of bush type)

## 7. 먹은 열매 이미지가 우측 상단에 보여지게 수정 FRUIT_ICON_UI_SETUP_GUIDE.md
backpack에 열매가 있으면(0이 아니면) 보여지는 방식

### 7.1. BushFruits.cs 수정: GetFruitVariant() 메서드 추가: 부시의 열매 타입을 반환
### 7.2. PlayerBackpack.cs 수정: 열매 타입 저장
- AddFruits() 메서드에 BushVariant fruitType 파라미터 추가
- currentFruitType 필드 추가: 현재 가진 열매 타입 저장
- TakeFruits() 호출 시 currentFruitType도 초기화
### 7.3.PlayerHarvest.cs 수정: 열매를 수확할 때 부시의 열매 타입도 함께 전달
### 7.4. FruitIconUI.cs 수정: 열매 종류별 이미지 표시
- fruitSprites 배열 추가: Green, Cyan, Yellow 순서로 3개의 열매 이미지
### 7.4. 에디터 설정
- Assets/Scripts/UI/FruitIconUI.cs 
- Assets > Scenes > level 을 선택하고 Hierarchy > Canvas에서 Image 생성(UI > Image)하고 이름을 FruitIcon으로 변경
- FruitIcon > Rect Transform에서 위치 정해주고, Image > Raycast Target 체크 해제
- FruitIcon의 Inspector에서 컴포넌트(Fruit Icon UI Script) 추가
- Fruit Icon UI Script에서 Backpack은 Player, Fruit Image는 FruitIcon, Fruit Sprites는 (0: fruit0P2, 1: fruit1P2, 2: fruit2P2로 설정)
- Hierarchy > Canvas > FruitIcon Inspector에서 체크박스 해제 (그래야 게임 시작 시 열매 아이콘 안보임)



## 8. Artifact Health 글씨를 Earth Health로 변경
- Assets/LocalizationStrings/artifactHealth.asset 파일에서 ‘Artifact Health’를 ‘Earth Health’로 변경
- Assets/Scenes/level.unity을 선택하고 Hierarchy > Canvas > ArtifactTxt의 Inspectordptj Text를 ‘Earth Health’로 변경



