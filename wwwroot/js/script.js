
// Preloader

window.addEventListener('load', function(){
    document.querySelector('.preloader').classList.add('opacity-0');
    setTimeout(function(){
        document.querySelector('.preloader').style.display = 'none';
    }, 1000);
});

// iTyped 

window.ityped.init(document.querySelector('.iTyped'), {
    strings: ["I'm a Web Dev", "I'm a .NET Developer", "I'm from UTC2", "I Love Coding", "I Enjoy Learning"],
    loop: true
});

// Portfolio Lighbox

const lightbox = document.querySelector('.lightbox'),
    lightboxImg = lightbox.querySelector('.lightbox-img'),
    lightboxText = lightbox.querySelector('.caption-text'),
    lightboxClose = lightbox.querySelector('.lightbox-close'),
    lightboxCounter = lightbox.querySelector('.caption-counter');

let itemIndex = 0;

for (let i = 0; i < totalPortfolioItem; i++) {
    portfolioItems[i].addEventListener('click', function(){
        itemIndex = i;
        changeItem();
        toggleLightbox();
    });
}

function toggleLightbox() {
    lightbox.classList.toggle('open');
}

function changeItem() {
    let imgSrc = portfolioItems[itemIndex].querySelector('.portfolio-img img').getAttribute('src');
    lightboxImg.src = imgSrc;
    lightboxText.innerHTML = portfolioItems[itemIndex].querySelector('h4').innerHTML;
    lightboxCounter.innerHTML = (itemIndex + 1) + " of " + totalPortfolioItem;
}

function prevItem() {
    if (itemIndex === 0) {
        itemIndex = totalPortfolioItem - 1;
    } else {
        itemIndex--;
    }
    changeItem();
}

function nextItem() {
    if (itemIndex === totalPortfolioItem - 1) {
        itemIndex = 0;
    } else {
        itemIndex++;
    }
    changeItem();
}

// close lightbox

lightbox.addEventListener('click', function(event){
    if(event.target === lightboxClose || event.target === lightbox){
        toggleLightbox();
    }
});

// Aside Navbar

const nav = document.querySelector('.nav'),
    navList = nav.querySelectorAll('li'),
    totalNavList = navList.length,
    allSection = document.querySelectorAll('.section'),
    totalSection = allSection.length;

for (let i = 0; i < totalNavList; i++) {
    const a = navList[i].querySelector('a');
    a.addEventListener('click', function(){
        // remove back section class
        removeBackSectionClass();

        for (let j = 0; j < totalNavList; j++) {
            if (navList[j].querySelector('a').classList.contains('active')) {
                // add back section class
                addBackSectionClass(j);
            }
            navList[j].querySelector('a').classList.remove('active');
        }

        this.classList.add('active');

        showSection(this);

        if (window.innerWidth < 1200) {
            asideSectionTogglerBtn();
        }

    });
}

function addBackSectionClass(num) 
{
    allSection[num].classList.add('back-section');
}

function removeBackSectionClass() 
{
    for (let i = 0; i < totalSection; i++) {
        allSection[i].classList.remove('back-section');
    }
}

function updateNav(element) 
{
    for (let i = 0; i < totalNavList; i++) {
        navList[i].querySelector('a').classList.remove('active');
        const target = element.getAttribute('href').split('#')[1];
        if (target === navList[i].querySelector('a').getAttribute('href').split('#')[1]) {
            navList[i].querySelector('a').classList.add('active');
        }
    }
}

document.querySelector('.hire-me').addEventListener('click', function(){
    const sectionIndex = this.getAttribute('data-section-index');
    addBackSectionClass(sectionIndex);
    showSection(this);
    updateNav(this);
    removeBackSectionClass();
});

function showSection(element) 
{
    for (let i = 0; i < totalSection; i++) {
        allSection[i].classList.remove('active');
    }

    const target = element.getAttribute('href').split('#')[1];

    document.querySelector('#'+target).classList.add('active');
}

const navTogglerBtn = document.querySelector('.nav-toggler'),
    aside = document.querySelector('.aside');

navTogglerBtn.addEventListener('click', asideSectionTogglerBtn);

function asideSectionTogglerBtn() 
{
    aside.classList.toggle('open');
    navTogglerBtn.classList.toggle('open');
    for (let i = 0; i < totalSection; i++) {
        allSection[i].classList.toggle('open');
    }
}

function initSkillsManagement() {
    const skillsList = document.querySelector("#skillsList");
    const addSkillBtn = document.querySelector("#addSkillBtn");

    if (!skillsList || !addSkillBtn) return;

    addSkillBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreateSkill"; 
        form.className = "skill-admin-item padd-15";

        form.innerHTML = `
            <div class="skill-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="row">
                <input type="text" name="SkillName" class="skill-name" placeholder="Enter skill name" />
                <div class="form-group padd-15">
                    <input type="range" name="Proficiency" min="0" max="100" value="0" />
                    <span class="proficiency-value">0%</span>
                </div>
            </div>
        `;
        const rangeInput = form.querySelector('input[type="range"]');
        const valueSpan = form.querySelector(".proficiency-value");
        rangeInput.addEventListener("input", function () {
            valueSpan.textContent = this.value + "%";
        });

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        skillsList.appendChild(form);
    });

    skillsList.querySelectorAll(".skill-admin-item").forEach(form => {
        const rangeInput = form.querySelector('input[type="range"]');
        const valueSpan = form.querySelector(".proficiency-value");
        if (rangeInput && valueSpan) {
            rangeInput.addEventListener("input", function () {
                valueSpan.textContent = this.value + "%";
            });
        }
    });

};
function initEducationManagement() {
    const educationList = document.querySelector("#educationList");
    const addEducationBtn = document.querySelector("#addEducationBtn");

    if (!educationList || !addEducationBtn) return;

    addEducationBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreateEducation";
        form.className = "timeline-admin-item";

        form.innerHTML = `
            <div class="timeline-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="timeline-form">
                <div class="row">
                    <div class="form-group padd-15">
                        <label>Start Year:</label>
                        <input type="number" name="StartYear" />
                    </div>
                    <div class="form-group padd-15">
                        <label>End Year:</label>
                        <input type="number" name="EndYear" />
                    </div>
                </div>
               <div class="row">
                     <div class="form-group padd-15">
                         <label>Title:</label>
                         <input type="text" name="Title" placeholder="Enter title" />
                     </div>
               </div>
               <div class="row">
                    <div class="form-group padd-15">
                         <label>Description:</label>
                         <textarea name="Description" rows="3" placeholder="Enter description"></textarea>
                     </div>
                </div>
            </div>
        `;

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        educationList.appendChild(form);
    });
}
function initExperienceManagement() {
    const experienceList = document.querySelector("#experienceList");
    const addExperienceBtn = document.querySelector("#addExperienceBtn");

    if (!experienceList || !addExperienceBtn) return;

    addExperienceBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreateExperience";
        form.className = "timeline-admin-item";

        form.innerHTML = `
            <div class="timeline-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="timeline-form">
                <div class="row">
                    <div class="form-group padd-15">
                        <label>Start Year:</label>
                        <input type="number" name="StartYear" />
                    </div>
                    <div class="form-group padd-15">
                        <label>End Year:</label>
                        <input type="number" name="EndYear" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group padd-15">
                         <label>Title:</label>
                         <input type="text" name="Title" placeholder="Enter job title" />
                     </div>
                </div>
                <div class="row">
                    <div class="form-group padd-15">
                        <label>Description:</label>
                        <textarea name="Description" rows="3" placeholder="Enter job description"></textarea>
                    </div>
                </div>
            </div>
        `;

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        experienceList.appendChild(form);
    });
}
function initServiceManagement() {
    const servicesList = document.querySelector("#servicesList");
    const addServiceBtn = document.querySelector("#addServiceBtn");

    if (!servicesList || !addServiceBtn) return;

    addServiceBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreateService"; 
        form.className = "service-admin-item padd-15";

        form.innerHTML = `
            <div class="service-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="service-info">
               <div class="row">
                    <div class="form-group">
                         <label>Service Name:</label>
                         <input type="text" name="ServiceName" placeholder="Enter service name" />
                     </div>

                     <div class="form-group">
                         <label>Icon:</label>
                         <input type="text" name="Icon" placeholder="Icon class (fa fa-code...)" />
                     </div>
                </div>
                <div class="row">
                     <div class="form-group">
                         <label>Description:</label>
                         <textarea name="Description" rows="2" placeholder="Enter description"></textarea>
                     </div>
                </div>
            </div>
        `;

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        servicesList.appendChild(form);
    });
}
function initPortfolioManagement() {
    const portfolioList = document.querySelector("#portfolioList");
    const addPortfolioBtn = document.querySelector("#addPortfolioBtn");

    if (!portfolioList || !addPortfolioBtn) return;

    addPortfolioBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreatePortfolio";
        form.className = "portfolio-admin-item padd-15";

        form.innerHTML = `
            <div class="portfolio-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="portfolio-info">
                <div class="row">
                    <div class="form-group">
                         <label>Title:</label>
                         <input type="text" name="Title" placeholder="Project Title" />
                     </div>

                     <div class="form-group">
                         <label>Image URL:</label>
                         <input type="text" name="Image" placeholder="Image URL" />
                     </div>
                     <div class="form-group">
                         <label>Link:</label>
                         <input type="text" name="Link" placeholder="Project Link" />
                     </div>
                     <div class="form-group">
                         <label>Category:</label>
                         <input type="text" name="Category" placeholder="Category" />
                     </div>
                </div>
                <div class="row">
                  <div class="form-group">
                     <label>Description:</label>
                     <textarea name="Description" rows="2" placeholder="Description"></textarea>
                 </div>
                </div>
            </div>
        `;

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        portfolioList.appendChild(form);
    });
}
function initBlogManagement() {
    const blogList = document.querySelector("#blogList");
    const addBlogBtn = document.querySelector("#addBlogBtn");

    if (!blogList || !addBlogBtn) return;

    addBlogBtn.addEventListener("click", function (e) {
        e.preventDefault();

        const form = document.createElement("form");
        form.method = "post";
        form.action = "/Admin/CreateBlog";
        form.className = "blog-admin-item padd-15";

        form.innerHTML = `
            <div class="blog-controls">
                <button type="submit" class="btn-icon btn-edit">
                    <i class="fa fa-save"></i>
                </button>
                <a href="#" class="btn-icon btn-delete btn-cancel">
                    <i class="fa fa-trash"></i>
                </a>
            </div>
            <div class="blog-info">
                <div class="row">
                    <div class="form-group">
                        <label>Title:</label>
                        <input type="text" name="Title" placeholder="Blog Title" />
                    </div>
                    <div class="form-group">
                        <label>Tag:</label>
                        <input type="text" name="Tag" placeholder="Tags, comma-separated" />
                    </div>
                    <div class="form-group">
                        <label>Summary:</label>
                        <textarea name="Summary" rows="2" placeholder="Blog Summary"></textarea>
                    </div>
                    <div class="form-group">
                        <label>Publish Date:</label>
                        <input type="date" name="PublishDate" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label>Content:</label>
                        <textarea name="Content" rows="4" placeholder="Blog Content"></textarea>
                    </div>
                </div>
            </div>
        `;

        form.querySelector(".btn-cancel").addEventListener("click", function (e) {
            e.preventDefault();
            form.remove();
        });

        blogList.appendChild(form);
    });
}


