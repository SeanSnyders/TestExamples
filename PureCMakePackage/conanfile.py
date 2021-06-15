from conans import ConanFile, tools

import os

class ConanRecipe(ConanFile):
    name = "PureCMakePackage"
    author = "Sean Snyders <sean.snyders@gmail.com>"
    url = "https://github.com/SeanSnyders/TestExamples.git"
    description = "Package containing only CMake utility files."
    license = "MIT"

    exports_sources = "PureCMakePackageConfig.cmake", "cmake/**"

    def set_version(self):
        content = tools.load(os.path.join(self.recipe_folder, "version.txt"))
        self.version = content.strip()

    def build(self):
        self.output.info("Running build in ConanRecipe...")
        # nothing to do here at the moment, just adding the empty method here to remove the Conan warning during package building

    def package(self):
        self.output.info("Running package in ConanRecipe...")
        # \NOTE: for self.copy() syntax, see https://docs.conan.io/en/1.34/reference/conanfile/methods.html?highlight=self%20copy#package
        self.copy(f"PureCMakePackageConfig.cmake", keep_path=False)
        self.copy(f"*", dst="cmake", src="cmake", keep_path=True) # keep relative paths for cmake files

    def package_info(self):
        self.output.info("Running package_info in ConanRecipe...")
        self.cpp_info.build_modules["cmake"].append("PureCMakePackageConfig.cmake")
        self.cpp_info.build_modules["cmake_paths"].append("PureCMakePackageConfig.cmake")
        self.cpp_info.build_modules["cmake_find_package"].append("PureCMakePackageConfig.cmake")
        # \WARNING: It does not seem that the CMakeDeps generator uses this, so how would one hook into existing CMake package that has its own *Config.cmake file ??
        self.cpp_info.build_modules["CMakeDeps"].append("PureCMakePackageConfig.cmake")